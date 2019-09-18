using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SignalRApplication.DTO
{
    public class User
    {
        public string iduser { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string active { get; set; }
        public DateTime? create_at { get; set; }
        public DateTime? update_at { get; set; }
        public DateTime? delete_at { get; set; }
    }
}
