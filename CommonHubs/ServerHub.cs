using System;

namespace CommonHubs
{
    using Microsoft.AspNet.SignalR;

    public class ServerHub : Hub
    {
        public void Test()
        {
            Console.WriteLine("Received message from Client1 on ServerHub...");
            var executingProcess = AppDomain.CurrentDomain.FriendlyName;
            Clients.All.addMessage(
                string.Format("hello from the server hub at {0} in assembly {1} ", DateTime.Now, executingProcess));
        }
    }
}
