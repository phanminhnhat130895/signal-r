using System;
using System.Collections.Generic;
using System.Text;

namespace SignalRApplication.DTO
{
    public class FriendShip
    {
        public int friendship_id { get; set; }
        public string personid_1 { get; set; }
        public string personid_2 { get; set; }
        public DateTime established_date { get; set; }
        public DateTime create_at { get; set; }
        public DateTime delete_at { get; set; }
    }
}
