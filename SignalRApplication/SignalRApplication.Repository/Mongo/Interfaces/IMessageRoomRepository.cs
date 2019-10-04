using SignalRApplication.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SignalRApplication.Repository.Mongo.Interfaces
{
    public interface IMessageRoomRepository
    {
        List<MessageRoom> getListMessage(string idRoom, int limit, int offset);

        int addMessageRoom(MessageRoom message);
    }
}
