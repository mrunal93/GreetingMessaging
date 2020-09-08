using GreetingMessagingModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreetingMessagingRepositoryLayer
{
    public interface IUserRepository
    {
        IEnumerable<UserModel> GetUsers();
        UserModel UserRegistrationData(UserModel user);
        UserModel UserLoginData(UserModel user);
        string GenerateToken(UserModel login, string type);
    }
}
