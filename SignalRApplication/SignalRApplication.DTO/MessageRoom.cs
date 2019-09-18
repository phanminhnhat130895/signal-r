using System;
using System.Collections.Generic;
using System.Text;

namespace SignalRApplication.DTO
{
    public class MessageRoom
    {
        public int idmessage { get; set; }
        public string idroom { get; set; }
        public string iduser_send { get; set; }
        public string message { get; set; }
        public DateTime? create_at { get; set; }
        public DateTime? delete_at { get; set; }
    }
}
