using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using SignalRApplication.DTO;
using SignalRApplication.Models;
using SignalRApplication.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRApplication.SignalR
{
    [Authorize]
    public class ChatHub : Hub<IChatHub>
    {
        private readonly static List<Models.User> _listConnection = new List<Models.User>();

        public async Task SendTitle(string message)
        {
            await Clients.All.SendTitle(message);
        }

        public async Task ReceiveMessage(Messenger message)
        {
            await Clients.All.SendMessage(message);
            //await Clients.All.SendAsync("server-send-message-from-user", user, message);
        }

        public void SendMessageToOne(string connectionId, Message message)
        {
            message.create_at = DateTime.Now;
            Clients.Client(connectionId).SendMessageToOne(message);
            Clients.Client(Context.ConnectionId).SendMessageToSelf(message);
        }

        public async Task SendUserConnect(string userId)
        {
            var user = _listConnection.Where(u => u.UserId == userId).FirstOrDefault();
            await Clients.Others.SendUserConnect(user);
        }

        public async Task SendListUser()
        {
            await Clients.Caller.SendListUser(_listConnection);
        }

        public void SendMessageToGroup(string groupId, Message message)
        {
            message.create_at = DateTime.Now;
            Clients.Group(groupId).SendMessageToGroup(groupId, message);
        }

        public override Task OnConnectedAsync()
        {
            //string name = Context.User.Identity.Name;
            //Groups.AddToGroupAsync(Context.ConnectionId, name);
            string UserId = Context.User.FindFirst("UserId")?.Value;
            string UserName = Context.User.FindFirst("UserName")?.Value;
            string ConnectionId = Context.ConnectionId;

            Models.User user = new Models.User();
            user.UserId = UserId;
            user.UserName = UserName;
            user.ConnectionId = ConnectionId;
            user.Message = new List<Messenger>();

            _listConnection.Add(user);

            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            var user = _listConnection.Where(u => u.UserId == Context.User.FindFirst("UserId")?.Value).FirstOrDefault();
            _listConnection.Remove(user);

            Clients.Others.SendListUser(_listConnection);

            return base.OnDisconnectedAsync(exception);
        }
    }
}
