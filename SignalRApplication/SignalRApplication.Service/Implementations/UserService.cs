using AutoMapper;
using Microsoft.Extensions.Logging;
using SignalRApplication.DTO;
using SignalRApplication.Repository.Infrastructure;
using SignalRApplication.Repository.Mongo.Interfaces;
using SignalRApplication.Service.Interfaces;
using SignalRApplication.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SignalRApplication.Service.Implementations
{
    public class UserService : IUserService
    {
        private IRepository<User> _userRepository;

        private IUnitOfWork _unitOfWork;

        private IUserRepository _mongoUserRepository;

        private ILogger _Logger;

        public UserService(IRepository<User> userRepository,
            IUnitOfWork unitOfWork,
            IUserRepository mongoUserRepository,
            ILoggerFactory loggerFactory)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _mongoUserRepository = mongoUserRepository;
            _Logger = loggerFactory.CreateLogger("UserService");
        }

        public UserViewModel Login(string UserName, string PassWord)
        {
            try
            {
                UserViewModel result = null;
                User user = _userRepository.FindSingle(x => x.username == UserName && x.password == PassWord && x.active == "1" && x.delete_at == null);
                if (user != null)
                {
                    result = Mapper.Map<UserViewModel>(user);
                }
                return result;
            }
            catch(Exception ex)
            {
                _Logger.LogError("UserService.Login: " + ex.ToString());
                return null;
            }
        }

        public UserViewModel MongoLogin(string userName, string passWord)
        {
            try
            {
                UserViewModel result = null;
                User userLogin = new User() { username = userName, password = passWord };
                User user = _mongoUserRepository.getLogin(userLogin);

                if(user != null)
                {
                    result = Mapper.Map<UserViewModel>(user);
                }

                return result;
            }
            catch(Exception ex)
            {
                _Logger.LogError("UserService.MongoLogin: " + ex.ToString());
                return null;
            }
        }
    }
}
