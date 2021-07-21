using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Hubs {
    public class ApplicationHub : Hub {

        // .Net Core does NOT support the OnReconnect override.

        private ILicenseService _licenseService;

        // This cache will be a Singleton eventually.
        private static readonly Dictionary<string, string> _connections = new Dictionary<string, string>();        // Map connection id => key id

        public ApplicationHub() {

            // TODO: Use IoC to make the LicenseService a Singleton, then remove the static from the RestClient member

            _licenseService = new LicenseService();
        }

        public override Task OnConnectedAsync() {

            var license = _licenseService.GetLicense();

            _connections.Add(Context.ConnectionId, license);

            // TODO: Put this in some cache based on the Hub's connection ID.

            var userName = Context.User.Identity.Name ?? "A user";

            // In a chat application, this is where that user might be marked as "awake" or "joined chat" (if they were not previously chatting)
            // An application might need to get a license key at this point.

            Clients.All.SendAsync("ReceiveMessage", "System", $"{userName} connected (License={license} -- Connection Id='{Context.ConnectionId}')");

            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception) {

            string license = null;

            if (_connections.TryGetValue(Context.ConnectionId, out license)) {
                _licenseService.ReturnLicense(license);
                _connections.Remove(Context.ConnectionId);
            }
 
            // Where is the "stopCalled" parameter?

                var userName = Context.User.Identity.Name ?? "A user";

            // In a chat application, this is where that user might be marked as "asleep" or "logged out"
            // An application might need to get a license key at this point.

            Clients.All.SendAsync("ReceiveMessage", "System", $"{userName} disconnected");
            return base.OnDisconnectedAsync(exception);
        }

        public async Task SendMessage(string user, string message) {

            var userName = Context.User.Identity.Name ?? "A user";

            // Calling ALL of the clients' ReceiveMessage methods that are attached to the hub on the client.

            await Clients.All.SendAsync("ReceiveMessage", $"({userName}) {user}", message);
        }
    }
}