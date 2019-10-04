using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SignalRApplication.DTO;
using SignalRApplication.Repository.Mongo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SignalRApplication.Repository.Mongo.Implements
{
    public class MessageRoomRepository : IMessageRoomRepository
    {
        private readonly MongoDBContext<MessageRoom> _context = null;
        private readonly string collectionName = "message-room";

        public MessageRoomRepository(IOptions<BaseDatabaseSetting> settings)
        {
            _context = new MongoDBContext<MessageRoom>(settings, collectionName);
        }

        public List<MessageRoom> getListMessage(string idRoom, int limit, int offset)
        {
            try
            {
                var result =_context._collection.Find(m => m.idroom == idRoom)
                                .ToList()
                                .OrderByDescending(m => m.create_at)
                                .Skip(offset * limit).Take(limit).ToList();

                return result.OrderBy(m => m.create_at).ToList();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public int addMessageRoom(MessageRoom message)
        {
            try
            {
                _context._collection.InsertOneAsync(message).Wait();
                return 1;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
