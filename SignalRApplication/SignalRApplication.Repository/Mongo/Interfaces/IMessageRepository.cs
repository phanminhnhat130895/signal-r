using SignalRApplication.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SignalRApplication.Repository.Mongo.Interfaces
{
    public interface IMessageRepository
    {
        List<Message> getMessage(string idUserSend, string isUserReceive, int limit, int offset);

        int saveMessage(Message message);
    }
}
