using Microsoft.AspNetCore.SignalR;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Microsoft.AspNetCore.Authorization;

namespace pwGazWater.Data
{
    public class ChatHub : Hub
    {
        public async Task Send(string user, string message, string messageTo)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message, messageTo);
        }
    }
}