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
    public class MessageRepository : IMessageRepository
    {
        private readonly MongoDBContext<Message> _context = null;
        private readonly string collectionName = "message";

        public MessageRepository(IOptions<BaseDatabaseSetting> settings)
        {
            _context = new MongoDBContext<Message>(settings, collectionName);
        }

        public List<Message> getMessage(string idUserSend, string idUserReceive, int limit, int offset)
        {
            try
            {
                List<Message> listMessage = _context._collection.Find(m =>
                                                (m.iduser_send == idUserSend && m.iduser_receive == idUserReceive) ||
                                                (m.iduser_receive == idUserSend && m.iduser_send == idUserReceive))
                                                .ToList()
                                                .OrderByDescending(x => x.create_at)
                                                .Skip(offset * limit).Take(limit).ToList();

                return listMessage.OrderBy(x => x.create_at).ToList();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public int saveMessage(Message message)
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
