using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRApplication.DTO;
using SignalRApplication.Service.Interfaces;
using SignalRApplication.SignalR;

namespace SignalRApplication.Controllers
{
    [Route("api/room")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private IRoomService _roomService;
        private IHubContext<ChatHub> _hub;

        public RoomController(IRoomService roomService,
            IHubContext<ChatHub> hub)
        {
            _roomService = roomService;
            _hub = hub;
        }

        //[Authorize]
        //[HttpGet, Route("join-room/{connectionId}")]
        //public IList<Room> JoinRoom(string connectionId)
        //{
        //    string userId = User.FindFirst("UserId")?.Value;
        //    var listRoom = _roomService.GetListRoom(userId);

        //    listRoom.ForEach(e =>
        //    {
        //        _hub.Groups.AddToGroupAsync(connectionId, e._id);
        //    });

        //    return listRoom;
        //}

        [Authorize]
        [HttpGet, Route("mongo-join-room/{connectionId}")]
        public IList<Room> MongoJoinRoom(string connectionId)
        {
            string userId = User.FindFirst("UserId")?.Value;
            var listRoom = _roomService.mongoGetListRoom(userId);

            listRoom.ForEach(r =>
            {
                _hub.Groups.AddToGroupAsync(connectionId, r.idroom);
            });

            return listRoom;
        }
    }
}