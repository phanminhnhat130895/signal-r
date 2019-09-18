using AutoMapper;
using SignalRApplication.DTO;
using SignalRApplication.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SignalRApplication.Service.AutoMapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserViewModel>();
            CreateMap<UserViewModel, User>();
            CreateMap<MessageRoom, Message>();
        }
    }
}
