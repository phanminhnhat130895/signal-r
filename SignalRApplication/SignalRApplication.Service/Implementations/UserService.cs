using AutoMapper;
using SignalRApplication.DTO;
using SignalRApplication.Repository.Infrastructure;
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

        public UserService(IRepository<User> userRepository,
            IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
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
                return null;
            }
        }
    }
}
