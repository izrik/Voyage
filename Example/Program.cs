using System;

namespace Example
{
    class Program
    {
        public static void Main(string[] args)
        {
            var app = new ExampleApp();
            Console.WriteLine("Starting the app on port 8080.");
            app.Run(8080);
        }
    }
}
