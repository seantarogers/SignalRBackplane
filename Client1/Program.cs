namespace Client1
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNet.SignalR.Client;

    class Program
    {
        private static IHubProxy hubProxy;

        private static void Main()
        {
            OpenConnectionToHub();
            RegisterResponseMessageHandler();

            Console.WriteLine("Client 1 connected to Server1...");

            while (true)
            {
                Console.WriteLine("press 's' and hit Enter to send a message to Hub1:");
                var line = Console.ReadLine();
                if (line == "s")
                {
                    SendMessage();
                }
            }
        }

        private static void OpenConnectionToHub()
        {
            var hubConnection = new HubConnection("http://localhost:8090");
            hubProxy = hubConnection.CreateHubProxy("serverhub");
            hubConnection.Start()
                .Wait();
        }

        private static void SendMessage()
        {
            hubProxy.Invoke("test")
                .ContinueWith(
                    task =>
                    {
                        using (var error = task.Exception.GetError())
                        {
                            Console.WriteLine(error);
                        }
                    },
                    TaskContinuationOptions.OnlyOnFaulted);
        }

        public static void AddMessage(string message)
        {
            Console.WriteLine("Client 1 has received a message: {0}", message);
        }

        private static void RegisterResponseMessageHandler()
        {
            hubProxy.On<string>("addMessage", AddMessage);
        }
    }
}
