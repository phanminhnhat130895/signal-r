using Newtonsoft.Json.Linq;
using SignalRApplication.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SignalRApplication.Service.Interfaces
{
    public interface IMessageService
    {
        IList<Message> GetListMessage(JObject clientData);

        void SaveMessage(Message message);
    }
}
