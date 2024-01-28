using Microsoft.AspNetCore.SignalR;

namespace SignalR.Api.Hubs
{
    public class MyHub : Hub
    {
        public static List<string> names = new List<string>();
        public async Task SendName(string name)
        {
            names.Add(name);

            await Clients.All.SendAsync("ReceiveName", name);
        }
        public async Task ReceiveName()
        {
            await Clients.All.SendAsync("ReceiveNames", names);
        }
    }
}
