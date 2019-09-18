using System;
using System.Collections.Generic;
using System.Text;

namespace SignalRApplication.DTO
{
    public class Room
    {
        public string idroom { get; set; }
        public string iduser { get; set; }
        public int series { get; set; }
        public string display_name { get; set; }
        public DateTime? create_at { get; set; }
        public DateTime? update_at { get; set; }
        public DateTime? delete_at { get; set; }
    }
}
