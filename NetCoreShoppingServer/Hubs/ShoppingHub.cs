using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace NetCoreShoppingServer.Hubs
{
    public class ShoppingHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            Console.WriteLine("Connection opened" + Context.ConnectionId);
            Clients.Client(Context.ConnectionId).SendAsync("ReceiveConnId", Context.ConnectionId);
            return base.OnConnectedAsync();
        }

        public async Task SendMessage(string message)
        {
            var routeOb = JsonConvert.DeserializeObject<dynamic>(message);
            Console.WriteLine("To: " + routeOb.To.ToString());
            Console.WriteLine("Message Recieved on: " + Context.ConnectionId);
            if (routeOb.To.ToString() == string.Empty)
            {
                Console.WriteLine("Broadcast");
                await Clients.All.SendAsync("ReceiveMessage", message);
            }
            else
            {
                string toClient = routeOb.To;
                Console.WriteLine("Targeted on: " + toClient);

                await Clients.Client(toClient).SendAsync("ReceiveMessage", message);
            }
        }
    }
}
