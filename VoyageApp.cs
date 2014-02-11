using System;
using Conveyor;
using System.Collections.Generic;
using System.Reflection;

namespace Voyage
{
    public abstract class VoyageApp
    {
        delegate Response Handler(Request request);

        protected VoyageApp()
        {
            var methods = this.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            foreach (MethodInfo method in methods)
            {
                var _resources = method.GetCustomAttributes(typeof(ResourceAttribute), true);
                var resources = (ResourceAttribute[])_resources;

                if (resources != null && resources.Length > 0)
                {
                    Handler del = (Handler)method.CreateDelegate(typeof(Handler), this);

                    foreach (var res in resources)
                    {
                        Resources.Add(res, del);
                    }
                }
            }
        }

        readonly Dictionary<ResourceAttribute, Handler> Resources = new Dictionary<ResourceAttribute, Handler>();

        public Response HandleRequest(Request request)
        {
            foreach (var kvp in Resources)
            {
                var res = kvp.Key;
                if (res.Path == request.Path)
                {
                    return kvp.Value(request);
                }
            }

            return new Response(404);
        }

        public void Run(int port=8080)
        {
            using (var server = new Server(port, this.HandleRequest))
            {
                server.ListenerThread.Thread.Join();
            }
        }
    }
}

