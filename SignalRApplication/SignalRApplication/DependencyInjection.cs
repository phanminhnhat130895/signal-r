using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SignalRApplication.DTO;
using SignalRApplication.Repository.Infrastructure;
using SignalRApplication.Service.Implementations;
using SignalRApplication.Service.Interfaces;
using SignalRApplication.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRApplication
{
    public class DependencyInjection
    {
        public static void Start(IConfiguration configuration, IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, EFUnitOfWork>();
            
            //services.AddTransient<IChatHub, ChatHub>();

            services.AddTransient<IRepository<User>, EFRepository<User>>();
            services.AddTransient<IUserService, UserService>();

            services.AddTransient<IRepository<Message>, EFRepository<Message>>();
            services.AddTransient<IMessageService, MessageService>();

            services.AddTransient<IRepository<Room>, EFRepository<Room>>();
            services.AddTransient<IRoomService, RoomService>();

            services.AddTransient<IRepository<MessageRoom>, EFRepository<MessageRoom>>();
            services.AddTransient<IMessageRoomService, MessageRoomService>();
        }
    }
}
