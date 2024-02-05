using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using SignalR.Api.Models;

namespace SignalR.Api.Hubs
{
    public class MyHub : Hub
    {
        private static List<string> names = new List<string>();
        public static int clientCount { get; set; } = 0;
        public static int TeamCount { get; set; } = 7;

        private readonly AppDbContext _appDbContext;

        public MyHub(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

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

        public async Task AddToGroup(string teamName) =>
            await Groups.AddToGroupAsync(Context.ConnectionId, teamName);

        public async Task SendNameByGroup(string name, string teamName)
        {
            var team = await _appDbContext.Teams.FirstOrDefaultAsync(x => x.Name == teamName);

            if (team != null)
            {
                team.Users.Add(new User
                {
                    Name = name
                });
            }
            else
            {
                var newTeam = new Team
                {
                    Name = teamName
                };
                newTeam.Users.Add(new User
                {
                    Name = name
                });

                await _appDbContext.Teams.AddAsync(newTeam);
            }
            await _appDbContext.SaveChangesAsync();

            await Clients.Group(teamName).SendAsync("ReceiveMessageByGroup", name, teamName);

        }

        public async Task GetNamesByGroup()
        {
            var teams = _appDbContext.Teams.Include(x => x.Users).Select(y => new
            {
                teamName = y.Name,
                users = y.Users.ToList(),
            });

            await Clients.All.SendAsync("ReceiveNamesByGroup", teams);
        }

        public async Task RemoveFromGroup(string teamName) =>
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, teamName);



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
