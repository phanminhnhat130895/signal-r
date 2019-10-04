using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SignalRApplication.DTO;
using SignalRApplication.Repository.Mongo.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SignalRApplication.Repository.Mongo.Implements
{
    public class RoomRepository : IRoomRepository
    {
        private MongoDBContext<Room> _context = null;
        private readonly string collectionName = "room";

        public RoomRepository(IOptions<BaseDatabaseSetting> settings)
        {
            _context = new MongoDBContext<Room>(settings, collectionName);
        }

        public List<Room> getListRoom(string userId)
        {
            try
            {
                return _context._collection.Find(r => r.iduser == userId).ToList();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
