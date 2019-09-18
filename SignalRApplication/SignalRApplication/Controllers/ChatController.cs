using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json.Linq;
using SignalRApplication.DTO;
using SignalRApplication.Service.Interfaces;
using SignalRApplication.SignalR;

namespace SignalRApplication.Controllers
{
    [Route("api/chat")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private IHubContext<ChatHub> _hub;
        private IMessageService _messageService;
        public ChatController(IHubContext<ChatHub> hub,
            IMessageService messageService)
        {
            _hub = hub;
            _messageService = messageService;
        }

        [HttpGet, Route("send-message")]
        public void SendMessage()
        {
            //_chatHub.SendMessage("Admin", "Message send from admin to all users").Wait();
            _hub.Clients.All.SendAsync("SendTitle", "Chat Application");
        }

        [Authorize]
        [HttpPost, Route("get-message")]
        public IList<Message> GetListMessage([FromBody]JObject clientData)
        {
            return _messageService.GetListMessage(clientData);
        }

        [Authorize]
        [HttpPost, Route("save-message")]
        public void SaveMessage([FromBody]Message message)
        {
            _messageService.SaveMessage(message);
        }
    }
}