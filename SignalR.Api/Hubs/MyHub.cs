﻿using Microsoft.AspNetCore.SignalR;

namespace SignalR.Api.Hubs
{
    public class MyHub : Hub
    {
        private static List<string> names = new List<string>();
        public static int clientCount { get; set; } = 0;
        public static int TeamCount { get; set; } = 7;
        public async Task SendName(string name)
        {

            if (names.Count >= TeamCount)
            {

                await Clients.Caller.SendAsync("Error", $"Takım en fazla {TeamCount} kişi olabilir.");

            }
            else
            {
                names.Add(name);

                await Clients.All.SendAsync("ReceiveName", name);

            }

        }
        public async Task GetNames()
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
