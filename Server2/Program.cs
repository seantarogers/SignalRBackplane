using System;

namespace Server2
{
    using CommonHubs;

    using Microsoft.Owin.Hosting;

    class Program
    {
        public ServerHub EnsuresDependencyScannerPullsInServerHub { get; set; }
        static void Main(string[] args)
        {
            const string Url = "http://localhost:8092";
            using (WebApp.Start(Url))
            {
                Console.WriteLine("Server2 started on port 8092...");
                Console.ReadLine();
            }
        }
    }
}
