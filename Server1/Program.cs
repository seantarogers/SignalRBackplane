using System;

namespace Server1
{
    using CommonHubs;

    using Microsoft.Owin.Hosting;

    class Program
    {
        public ServerHub EnsuresDependencyScannerPullsInServerHub { get; set; }
        static void Main()
        {
            const string Url = "http://localhost:8090";
            using (WebApp.Start(Url))
            {
                Console.WriteLine("Server1 started on port 8090...");
                Console.ReadLine();
            }
        }
    }
}
