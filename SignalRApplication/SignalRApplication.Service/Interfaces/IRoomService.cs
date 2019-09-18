using SignalRApplication.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SignalRApplication.Service.Interfaces
{
    public interface IRoomService
    {
        List<Room> GetListRoom(string userId);
    }
}
