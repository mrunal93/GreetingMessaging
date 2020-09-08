using GreetingMessagingModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreetingMessagingBussinessLayer
{
    public interface IUserBussiness
    {
        IEnumerable<UserModel> GetUsers();
        UserModel UserRegistrationData(UserModel user);
        UserModel UserLoginData(UserModel user);
        string GenerateToken(UserModel login, string type);
    }
}
