using Microsoft.AspNetCore.SignalR;

namespace TP06.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SubmitMessage(string user, string message)
        {
            string time = DateTime.Now.ToString("T");

            await Clients.All.SendAsync("NewMessage", user, message, time);
        }
    }
}
