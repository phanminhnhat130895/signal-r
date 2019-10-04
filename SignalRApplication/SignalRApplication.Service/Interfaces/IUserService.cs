using SignalRApplication.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SignalRApplication.Service.Interfaces
{
    public interface IUserService
    {
        UserViewModel Login(string UserName, string PassWord);

        UserViewModel MongoLogin(string userName, string passWord);
    }
}
