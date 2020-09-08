using GreetingMessagingModelLayer;
using GreetingMessagingRepositoryLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreetingMessagingBussinessLayer
{
    public class UserBussiness : IUserBussiness
    {
        public readonly IUserRepository userRepository;
        public UserBussiness(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public IEnumerable<UserModel> GetUsers()
        {
            return userRepository.GetUsers();
        }

        public UserModel UserRegistrationData(UserModel user)
        {
            return userRepository.UserRegistrationData(user);
        }

        public UserModel UserLoginData(UserModel user)
        {
            return userRepository.UserLoginData(user);
        }
        public string GenerateToken(UserModel login, string type)
        {
            return userRepository.GenerateToken(login, type);
        }

    }
}
