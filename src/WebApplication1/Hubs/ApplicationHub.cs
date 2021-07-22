using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Interfaces;

namespace WebApplication1.Hubs {
    public class ApplicationHub : Hub {

        // .Net Core does NOT support the OnReconnect override.

        // This cache will be a Singleton eventually.
        private static readonly Dictionary<string, string> _connections = new Dictionary<string, string>();        // Map connection id => key id
        private readonly ILicenseService _licenseService;

        public ApplicationHub(ILicenseService licenseService) {
            _licenseService = licenseService;
        }

        public override Task OnConnectedAsync() {

            var license = _licenseService.GetLicense();

            _connections.Add(Context.ConnectionId, license);

            var userName = Context.User.Identity.Name ?? "A user";

            // In a chat application, this is where that user might be marked as "awake" or "joined chat" (if they were not previously chatting)
            // An application might need to get a license key at this point.

            Clients.All.SendAsync("ReceiveMessage", "System", $"{userName} connected (License={license} -- Connection Id='{Context.ConnectionId}')");

            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception) {    // Where is the "stopCalled" parameter?

            string license = null;

            if (_connections.TryGetValue(Context.ConnectionId, out license)) {
                _licenseService.ReturnLicense(license);
                _connections.Remove(Context.ConnectionId);
            }

            try {
                var userName = Context?.User?.Identity?.Name ?? "A user";

                // In a chat application, this is where that user might be marked as "asleep" or "logged out"
                // An application might need to get a license key at this point.

                Clients.All.SendAsync("ReceiveMessage", "System", $"{userName} disconnected");
            } catch (Exception) {
            }

            return base.OnDisconnectedAsync(exception);
        }

        public async Task SendMessage(string user, string message) {

            var userName = Context.User.Identity.Name ?? "A user";

            string license = null;

            if (_connections.TryGetValue(Context.ConnectionId, out license)) {

                if (!_licenseService.IsValidLicense(license)) {

                    // Don't send the actual message because the user does not have a valid license.

                    message = "!!NEEDS A NEW LICENSE!!";
                }

                // Calling ALL of the clients' ReceiveMessage methods that are attached to the hub on the client.

                await Clients.All.SendAsync("ReceiveMessage", $"({userName}) {user}", message);
            }
        }
    }
}