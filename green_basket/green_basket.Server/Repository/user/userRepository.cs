using green_basket.Server.Entities;
using green_basket.Server.Repository.user.Interface;
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace green_basket.Server.Repository.user
{
    public class userRepository : IUserRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public userRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = this._configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<List<User>> Getall()
        {
            List<User> users = new List<User>();
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = _connectionString;
            try
            {
                string query = "select * from user";
                MySqlCommand command = new MySqlCommand(query, connection);
                await connection.OpenAsync();
                MySqlDataReader reader = command.ExecuteReader();
                while (await reader.ReadAsync())
                {
                    int user_Id = int.Parse(reader["user_Id"].ToString());
                    string first_name = reader["first_name"].ToString();
                    string last_name = reader["last_name"].ToString();
                    string email = reader["email"].ToString();
                    string password = reader["password"].ToString();
                    string address = reader["address"].ToString();
                    string mobile_no = reader["mobile_no"].ToString();
                    string role = reader["role"].ToString(); ;

                    User user = new User()
                    {
                        user_Id = user_Id,
                        first_name = first_name,
                        last_name = last_name,
                        email = email,
                        password = password,
                        address = address,
                        mobile_no = mobile_no,
                        role = role,
                    }
                }
                users.Add(user);
            }
            await reader.CloseAsync();
        }
        Catch(Exception e)
        {
            throw;
        }
        finally
        {
           await connection.CloseAsync();
        }
         return users;
    }
}
