using Microsoft.AspNetCore.SignalR;
using SignalRApplication.DTO;
using SignalRApplication.Repository.Infrastructure;
using SignalRApplication.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SignalRApplication.Service.Implementations
{
    public class RoomService : IRoomService
    {
        private IRepository<Room> _roomRepository;
        private IUnitOfWork _unitOfWork;

        public RoomService(IRepository<Room> roomRepository,
            IUnitOfWork unitOfWork)
        {
            _roomRepository = roomRepository;
            _unitOfWork = unitOfWork;
        }

        public List<Room> GetListRoom(string userId)
        {
            try
            {
                var result = _roomRepository.FindAll(x => x.iduser == userId).ToList();
                return result;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
