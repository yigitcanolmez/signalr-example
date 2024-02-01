using Microsoft.AspNetCore.SignalR;

namespace SignalR.Api.Hubs
{
    public class MyHub : Hub
    {
        private static List<string> names = new List<string>();
        public static int clientCount { get; set; } = 0;

        public async Task SendName(string name)
        {
            names.Add(name);

            await Clients.All.SendAsync("ReceiveName", name);
        }
        public async Task ReceiveName()
        {
            await Clients.All.SendAsync("ReceiveNames", names);
        }

        public async override Task OnConnectedAsync()
        {
            clientCount++;

            await ReceiveClientCount();

            await base.OnConnectedAsync();
        }
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            clientCount--;

            await ReceiveClientCount();

            await base.OnDisconnectedAsync(exception);
        }

        private async Task ReceiveClientCount()
        {
            await Clients.All.SendAsync("ReceiveClientCount", clientCount);
        }
    }
}
