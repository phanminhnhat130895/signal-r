using SignalRApplication.DTO;
using SignalRApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRApplication.SignalR
{
    public interface IChatHub
    {
        Task SendTitle(string message);

        Task SendMessage(Messenger message);

        Task SendListUser(List<Models.User> listUser);

        Task SendUserConnect(Models.User user);

        Task SendMessageToOne(Message message);

        Task SendMessageToSelf(Message message);

        Task SendMessageToGroup(string idGroup, Message message);
    }
}
