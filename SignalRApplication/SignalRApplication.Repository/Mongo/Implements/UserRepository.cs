using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SignalRApplication.DTO;
using SignalRApplication.Repository.Mongo.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SignalRApplication.Repository.Mongo.Implements
{
    public class UserRepository : IUserRepository
    {
        private readonly MongoDBContext<User> _context = null;
        private readonly string collectionName = "user";

        public UserRepository(IOptions<BaseDatabaseSetting> settings)
        {
            _context = new MongoDBContext<User>(settings, collectionName);
        }

        public User getLogin(User user)
        {
            try
            {
                return _context._collection.Find(u => u.username == user.username && u.password == user.password && u.active == "1").SingleOrDefault();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
