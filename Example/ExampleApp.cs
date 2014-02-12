using System;
using Conveyor;
using Voyage;
using System.Collections.Generic;

namespace Example
{
    public class ExampleApp : VoyageApp
    {
        [Resource("/")]
        public Response MainPage(Request request)
        {
            var body = RenderTemplate("files/index.mustache",
                new { message = "this is the message" });

            return new Response(200, headers: new [] {"Content-type", "text/html"}, body: body);
        }
    }
}

