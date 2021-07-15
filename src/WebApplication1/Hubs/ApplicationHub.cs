using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace WebApplication1.Hubs {
    public class ApplicationHub : Hub {

        // .Net Core does NOT support the OnReconnect override.

        public override Task OnConnectedAsync() {

            // In a chat application, this is where that user might be marked as "awake" or "joined chat" (if they were not previously chatting)
            // An application might need to get a license key at this point.

            Clients.All.SendAsync("ReceiveMessage", "System", "A user connected");
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception) {

            // In a chat application, this is where that user might be marked as "asleep" or "logged out"
            // An application might need to get a license key at this point.

            Clients.All.SendAsync("ReceiveMessage", "System", "A user disconnected");
            return base.OnDisconnectedAsync(exception);
        }

        public async Task SendMessage(string user, string message) {

            // Calling ALL of the clients' ReceiveMessage methods that are attached to the hub on the client.

            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}