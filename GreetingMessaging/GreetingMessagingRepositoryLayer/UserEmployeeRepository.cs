using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using GreetingMessagingModelLayer;
using System.Data;

namespace GreetingMessagingRepositoryLayer
{
    public class UserEmployeeRepository : IUserEmployeeRepository
    {
        private readonly IConfiguration configuration;
        private readonly string connectionString;
        private readonly SqlConnection sqlConnection;
        public UserEmployeeRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.connectionString = this.configuration.GetConnectionString("UserDbConnection");
            this.sqlConnection = new SqlConnection(connectionString);
        }

        public IEnumerable<GreetingEmployeeDetails> GetAllEmployees()
        {
            List<GreetingEmployeeDetails> listEmployee = new List<GreetingEmployeeDetails>();
            SqlCommand sqlCommand = new SqlCommand("spGetGreetingEmployee", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                GreetingEmployeeDetails empoyeeDetails =new GreetingEmployeeDetails();

                empoyeeDetails.id = Convert.ToInt32(sqlDataReader["id"]);
                empoyeeDetails.First_Name = sqlDataReader["First_Name"].ToString();
                empoyeeDetails.Last_Name = sqlDataReader["Last_Name"].ToString();
                empoyeeDetails.Email = sqlDataReader["Email"].ToString();
                empoyeeDetails.Mobile_Number = sqlDataReader["Mobile_Number"].ToString();
                listEmployee.Add(empoyeeDetails);               
            }
            return listEmployee;
        }

        public GreetingEmployeeDetails AddEmployeeData(GreetingEmployeeDetails empoyeeDetails)
        {
            SqlCommand sqlCommand = new SqlCommand("spAddGreetingEmployee", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@FirstName",empoyeeDetails.First_Name );
            sqlCommand.Parameters.AddWithValue("@LastName",empoyeeDetails.Last_Name);
            sqlCommand.Parameters.AddWithValue("@Email", empoyeeDetails.Email);
            sqlCommand.Parameters.AddWithValue("@MobileNumber", empoyeeDetails.Mobile_Number);

            sqlConnection.Open();
            int i = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return empoyeeDetails;
        }
        public object DeleteEmployeeData(int Id)
        {
            SqlCommand sqlCommand = new SqlCommand("spDeleteGreetingEmployee", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@Id", Id);

            sqlConnection.Open();
            var result = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return result;
        }

        public GreetingEmployeeDetails UpdateEmployeeData(GreetingEmployeeDetails empoyeeDetails)
        {
            SqlCommand sqlCommand = new SqlCommand("spUpdateEmployee", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@EmpId", empoyeeDetails.id);
            sqlCommand.Parameters.AddWithValue("@FirstName", empoyeeDetails.First_Name);
            sqlCommand.Parameters.AddWithValue("@LastName", empoyeeDetails.Last_Name);
            sqlCommand.Parameters.AddWithValue("@Email", empoyeeDetails.Email);
            sqlCommand.Parameters.AddWithValue("@MobileNumber", empoyeeDetails.Mobile_Number);

            sqlConnection.Open();
            int i = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return empoyeeDetails;
        }


    }
}
