using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using Speed.Pages;

namespace Speed.Hubs
{
    public class GameHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            // sends to all endpoints
            //await Clients.All.SendAsync("ReceiveMessage", user, message);
            // sends to the user that called the function
            //await Clients.Caller.SendAsync("ReceiveMessage", user, message.ToUpper());
            // sends to all other users except the person who called the function
            await Clients.Others.SendAsync("ReceiveMessage", user, message);
        }

        public async Task EchoMessage(string user, string message)
        {
            await Clients.Caller.SendAsync("ReceiveMessage", user, message.ToUpper());
        }
    }
}
