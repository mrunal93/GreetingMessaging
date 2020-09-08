using GreetingMessagingModelLayer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GreetingMessagingRepositoryLayer
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration configuration;
        private readonly string connectionString;
        private readonly SqlConnection sqlConnection;

        public UserRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.connectionString = this.configuration.GetConnectionString("UserDbConnection");
            this.sqlConnection = new SqlConnection(this.connectionString);
        }

        public IEnumerable<UserModel> GetUsers()
        {
            List<UserModel> userModelsList = new List<UserModel>();

            SqlCommand sqlCommand = new SqlCommand("spGetUserTypeData", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                UserModel userType = new UserModel();

                userType.Email = sqlDataReader["Email"].ToString();
                userType.Password = sqlDataReader["Password"].ToString();

                userModelsList.Add(userType);
            }
            return userModelsList;
        }

        public string EncodePassword(string password)
        {
                byte[] encPassword = new byte[password.Length];
                encPassword = Encoding.UTF8.GetBytes(password);
                string encodedPassword = Convert.ToBase64String(encPassword);
                return encodedPassword;
            
            
        }

        public UserModel UserRegistrationData(UserModel user)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("spUserRegistered", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                var encodedPassword = this.EncodePassword(user.Password);

                sqlCommand.Parameters.AddWithValue("@email", user.Email);
                sqlCommand.Parameters.AddWithValue("@password", encodedPassword);

                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }catch(Exception e)
            {
                throw new Exception("Exception occured: "+e);
            }
            
            return user;
        }

        public UserModel UserLoginData(UserModel user)
        {
            try
            {
               
                SqlCommand sqlCommand = new SqlCommand("spUserLogin", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@email", user.Email);
                sqlCommand.Parameters.AddWithValue("@password", user.Password);


                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();

            }
            catch (Exception e)
            {
                throw new Exception("Exception occured: " + e);
            }

            return user;
        }
       
        public string GenerateToken(UserModel login, string type)
        {

            try
            {
                var symmetricSecuritykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));

                var signingCreds = new SigningCredentials(symmetricSecuritykey, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Role, "User"));
                claims.Add(new Claim("Email", login.Email.ToString()));
                claims.Add(new Claim("Password", login.Password.ToString()));
                var token = new JwtSecurityToken(configuration["Jwt:Issuer"],
                    configuration["Jwt:Issuer"],
                    claims,
                    expires: DateTime.Now.AddHours(120),
                    signingCredentials: signingCreds);
                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
