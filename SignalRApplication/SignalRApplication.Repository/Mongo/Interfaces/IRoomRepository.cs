using SignalRApplication.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SignalRApplication.Repository.Mongo.Interfaces
{
    public interface IRoomRepository
    {
        List<Room> getListRoom(string userId);
    }
}
