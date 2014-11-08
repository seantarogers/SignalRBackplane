using System;

namespace Client2
{
    using Microsoft.AspNet.SignalR.Client;

    class Program
    {
        private static IHubProxy hubProxy;

        private static void Main()
        {
            OpenConnectionToHub();
            RegisterResponseHandlers();

            Console.WriteLine("Client 2 connected to Server2...");
            Console.ReadLine();

        }

        private static void OpenConnectionToHub()
        {
            var hubConnection = new HubConnection("http://localhost:8092");
            hubProxy = hubConnection.CreateHubProxy("serverhub");
            hubConnection.Start()
                .Wait();
        }

        public static void AddMessage(string message)
        {
            Console.WriteLine(string.Format("Client 2 has received a message {0}", message));
        }

        private static void RegisterResponseHandlers()
        {
            hubProxy.On<string>("addMessage", AddMessage);
        }
    }
}
