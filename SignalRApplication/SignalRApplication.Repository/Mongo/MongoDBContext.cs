using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace SignalRApplication.Repository.Mongo
{
    public class MongoDBContext<T>
    {
        private readonly IMongoDatabase _database = null;
        private string CollectionName = "";

        public MongoDBContext(IOptions<BaseDatabaseSetting> settings, string collectionName)
        {
            CollectionName = collectionName;
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.DatabaseName);
        }

        public IMongoCollection<T> _collection
        {
            get
            {
                return _database.GetCollection<T>(CollectionName);
            }
        }
    }

    public class BaseDatabaseSetting
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
