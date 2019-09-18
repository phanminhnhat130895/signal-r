using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SignalRApplication.DTO;
using SignalRApplication.Service.Interfaces;

namespace SignalRApplication.Controllers
{
    [Route("api/message-room")]
    [ApiController]
    public class MessageRoomController : ControllerBase
    {
        private IMessageRoomService _messageRoomService;

        public MessageRoomController(IMessageRoomService messageRoomService)
        {
            _messageRoomService = messageRoomService;
        }

        [Authorize]
        [HttpPost, Route("get-list-message")]
        public List<Message> GetListMessage([FromBody]JObject clientData)
        {
            return _messageRoomService.GetListMessage(clientData);
        }

        [Authorize]
        [HttpPost, Route("add-message")]
        public void AddMessage([FromBody]MessageRoom model)
        {
            _messageRoomService.AddMessage(model);
        }
    }
}