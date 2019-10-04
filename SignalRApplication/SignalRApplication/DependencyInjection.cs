using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SignalRApplication.DTO;
using SignalRApplication.Repository.Infrastructure;
using SignalRApplication.Repository.Mongo;
using SignalRApplication.Repository.Mongo.Implements;
using SignalRApplication.Repository.Mongo.Interfaces;
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
            // config mongo
            services.Configure<BaseDatabaseSetting>(options =>
            {
                options.ConnectionString = configuration.GetSection("MongoDb:ConnectionString").Value;
                options.DatabaseName = configuration.GetSection("MongoDb:DatabaseName").Value;
            });

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IMessageRepository, MessageRepository>();
            services.AddTransient<IRoomRepository, RoomRepository>();

            // Unit of work
            services.AddTransient<IUnitOfWork, EFUnitOfWork>();
            
            //services.AddTransient<IChatHub, ChatHub>();

            // Service
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
