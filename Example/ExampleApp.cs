using System;
using Conveyor;
using Voyage;

namespace Example
{
    public class ExampleApp : VoyageApp
    {
        [Resource("/")]
        public Response MainPage(Request request)
        {
            return new Response(200, body: "This is the main page.");
        }
    }
}

