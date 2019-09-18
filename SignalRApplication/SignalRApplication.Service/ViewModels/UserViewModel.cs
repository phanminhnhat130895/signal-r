using System;
using System.Collections.Generic;
using System.Text;

namespace SignalRApplication.Service.ViewModels
{
    public class UserViewModel
    {
        public string iduser { get; set; }
        public string username { get; set; }
        public string active { get; set; }
        public DateTime? create_at { get; set; }
        public DateTime? update_at { get; set; }
        public DateTime? delete_at { get; set; }
    }
}
