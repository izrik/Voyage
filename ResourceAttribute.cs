using System;

namespace Voyage
{
    [AttributeUsage(AttributeTargets.Method, Inherited = true)]
    public class ResourceAttribute : Attribute
    {
        public string Path { get; set; }

        public ResourceAttribute(string path)
        {
            Path = path;
        }
    }
}

