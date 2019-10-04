using Newtonsoft.Json.Linq;
using SignalRApplication.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SignalRApplication.Service.Interfaces
{
    public interface IMessageRoomService
    {
        List<Message> GetListMessage(JObject clientData);

        void AddMessage(MessageRoom model);

        List<Message> mongoGetListMessage(JObject clientData);

        void mongoAddMessage(MessageRoom message);
    }
}
