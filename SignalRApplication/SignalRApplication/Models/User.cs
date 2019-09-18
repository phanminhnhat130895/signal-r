using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRApplication.Models
{
    public class User
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string ConnectionId { get; set; }
        public bool IsHaveNewMessage { get; set; }
        public List<Messenger> Message { get; set; }
    }
}
