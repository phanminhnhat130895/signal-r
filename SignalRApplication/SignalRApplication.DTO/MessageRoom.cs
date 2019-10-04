using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SignalRApplication.DTO
{
    public class MessageRoom
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        //public int idmessage { get; set; }
        public string idroom { get; set; }
        public string iduser_send { get; set; }
        public string message { get; set; }
        public DateTime? create_at { get; set; }
        public DateTime? delete_at { get; set; }
    }
}
