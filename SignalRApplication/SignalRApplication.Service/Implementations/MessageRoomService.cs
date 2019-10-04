using AutoMapper;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using SignalRApplication.DTO;
using SignalRApplication.Repository.Infrastructure;
using SignalRApplication.Repository.Mongo.Interfaces;
using SignalRApplication.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SignalRApplication.Service.Implementations
{
    public class MessageRoomService : IMessageRoomService
    {
        private IRepository<MessageRoom> _messageRoomRepository;
        private IUnitOfWork _unitOfWork;
        private IMessageRoomRepository _mongoMessageRoomRepository;
        private ILogger _Logger;

        public MessageRoomService(IRepository<MessageRoom> messageRoomRepository,
            IUnitOfWork unitOfWork,
            IMessageRoomRepository mongoMessageRoomRepository,
            ILoggerFactory loggerFactory)
        {
            _messageRoomRepository = messageRoomRepository;
            _unitOfWork = unitOfWork;
            _mongoMessageRoomRepository = mongoMessageRoomRepository;
            _Logger = loggerFactory.CreateLogger("MessageRoomService");
        }

        public List<Message> GetListMessage(JObject clientData)
        {
            try
            {
                string idRoom = clientData["idRoom"].ToString();
                int limit = int.Parse(clientData["limit_mess"].ToString());
                int offset = int.Parse(clientData["offset_mess"].ToString());
                var listMess = _messageRoomRepository.FindAll(x => x.idroom == idRoom)
                                                     .OrderByDescending(x => x.create_at)
                                                     .Skip(offset * limit).Take(limit).ToList();

                var result = Mapper.Map<Message[]>(listMess).OrderBy(x => x.create_at).ToList();

                return result;
            }
            catch(Exception ex)
            {
                _Logger.LogError("MessageRoomService.GetListMessage: " + ex.ToString());
                return null;
            }
        }

        public void AddMessage(MessageRoom model)
        {
            try
            {
                model.create_at = DateTime.Now;
                _messageRoomRepository.Add(model);
                _unitOfWork.Commit();
            }
            catch(Exception ex)
            {
                _Logger.LogError("MessageRoomService.AddMessage: " + ex.ToString());
            }
        }

        public List<Message> mongoGetListMessage(JObject clientData)
        {
            try
            {
                string idRoom = clientData["idRoom"].ToString();
                int limit = int.Parse(clientData["limit_mess"].ToString());
                int offset = int.Parse(clientData["offset_mess"].ToString());

                var listMess = _mongoMessageRoomRepository.getListMessage(idRoom, limit, offset);
                var result = Mapper.Map<Message[]>(listMess).ToList();

                return result;
            }
            catch(Exception ex)
            {
                _Logger.LogError("MessageRoomService.mongoGetListMessage: " + ex.ToString());
                return null;
            }
        }

        public void mongoAddMessage(MessageRoom message)
        {
            try
            {
                message.create_at = DateTime.Now;
                _mongoMessageRoomRepository.addMessageRoom(message);
            }
            catch(Exception ex)
            {
                _Logger.LogError("MessageRoomService.mongoAddMessage: " + ex.ToString());
            }
        }
    }
}
