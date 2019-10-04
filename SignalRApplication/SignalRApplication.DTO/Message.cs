using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SignalRApplication.DTO
{
    public class Message
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        //public int idmessage { get; set; }
        public string iduser_send { get; set; }
        public string iduser_receive { get; set; }
        public string message { get; set; }
        public DateTime? create_at { get; set; }
        public DateTime? delete_at { get; set; }
    }
}
