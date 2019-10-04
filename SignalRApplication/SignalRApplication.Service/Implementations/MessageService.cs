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
    public class MessageService : IMessageService
    {
        //private IRepository<Message> _messageRepository;

        private IUnitOfWork _unitOfWork;

        private ILogger _Logger;

        private IMessageRepository _mongoMessageRepository;

        public MessageService(IRepository<Message> messageRepository,
            IUnitOfWork unitOfWork,
            ILoggerFactory loggerFactory,
            IMessageRepository mongoMessageRepository)
        {
            //_messageRepository = messageRepository;
            _unitOfWork = unitOfWork;
            _Logger = loggerFactory.CreateLogger("MessageService");
            _mongoMessageRepository = mongoMessageRepository;
        }

        //public IList<Message> GetListMessage(JObject clientData)
        //{
        //    try
        //    {
        //        string idUser_send = clientData["iduser_send"].ToString();
        //        string idUser_receive = clientData["iduser_receive"].ToString();
        //        int limit = int.Parse(clientData["limit_mess"].ToString());
        //        int offset = int.Parse(clientData["offset_mess"].ToString());

        //        IList<Message> result = _messageRepository.FindAll(x => 
        //                                                  (x.iduser_send == idUser_send && x.iduser_receive == idUser_receive) ||
        //                                                  (x.iduser_send == idUser_receive && x.iduser_receive == idUser_send)
        //                                                  ).OrderByDescending(x => x.create_at)
        //                                                  .Skip(offset * limit).Take(limit).ToList();

        //        return result.OrderBy(x => x.create_at).ToList();
        //    }
        //    catch(Exception ex)
        //    {
        //        _Logger.LogError("MessageService.GetListMessage: " + ex.ToString());
        //        return null;
        //    }
        //}

        //public void SaveMessage(Message message)
        //{
        //    try
        //    {
        //        message.create_at = DateTime.Now;
        //        _messageRepository.Add(message);
        //        _unitOfWork.Commit();
        //    }
        //    catch(Exception ex)
        //    {
        //        _Logger.LogError("MessageService.SaveMessage: " + ex.ToString());
        //    }
        //}

        public IList<Message> mongoGetListMessage(JObject clientData)
        {
            try
            {
                string idUserSend = clientData["iduser_send"].ToString();
                string idUserReceive = clientData["iduser_receive"].ToString();
                int limit = int.Parse(clientData["limit_mess"].ToString());
                int offset = int.Parse(clientData["offset_mess"].ToString());

                return _mongoMessageRepository.getMessage(idUserSend, idUserReceive, limit, offset);
            }
            catch(Exception ex)
            {
                _Logger.LogError("MessageService.GetListMessage: " + ex.ToString());
                return null;
            }
        }

        public void mongoSaveMessage(Message message)
        {
            try
            {
                message.create_at = DateTime.Now;
                _mongoMessageRepository.saveMessage(message);
            }
            catch(Exception ex)
            {
                _Logger.LogError("MessageService.mongoSaveMessage: " + ex.ToString());
            }
        }
    }
}
