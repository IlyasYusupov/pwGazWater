using Microsoft.AspNetCore.SignalR;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Microsoft.AspNetCore.Authorization;

namespace pwGazWater.Data
{
    public class ChatHub : Hub
    {
        public async Task Send(string message, string messageTo)
        {
            if (Context.UserIdentifier is string userName)
            {
                await Clients.Users(messageTo, userName).SendAsync("ReceiveMessage", message, userName);
            }
        }
        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("Notify", $"Приветствуем {Context.UserIdentifier}");
            await base.OnConnectedAsync();
        }
    }
}