using green_basket.Server.Entities;
using green_basket.Server.Repository.user.Interface;
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using System.Linq.Expressions;

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
                        this.user_Id = user_Id;
                        this.first_name = first_name;
                        this.last_name = last_name;
                        this.email = email;
                        this.password = password;
                        this.address = address;
                        this.mobile_no = mobile_no;
                        this.role = role;
                    };
                    users.Add(user);
                }
                await reader.CloseAsync();
            }
             Catch(Exception)
            {
                throw;
            }
             finally
             {
                await connection.CloseAsync();
             }
            return users;
        }

        public async Task<bool> Insert(User user)
        {
            bool status = false;
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = _connectionString;
            try
            {
                string query = "insert into(first_name,last_name,address,role,password,email,mobile_no)" +
                    " user values(@first_name,@last_name,@address,@role,@password,@email,@mobile_no)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@first_name", first_name);
                command.Parameters.AddWithValue("@last_name", last_name);
                command.Parameters.AddWithValue("@address", address);
                command.Parameters.AddWithValue("@role", role);
                command.Parameters.AddWithValue("@password", password);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@mobile_no", mobile_no);

                connection.Open();
                int rowsaffected = command.ExecuteNonQuery();
                if(rowsaffected > 0)
                {
                    status = true;
                }
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                await connection.CloseAsync();
            }
            return status;
        }
       
        public async Task<bool> UpdateDetails(User user)
        {
            bool status = false;
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = _connectionString;
            try
            {
                string query = "update user set first_name = @first_name,last_name = @last_name," +
                    "address = @address,role = @role, mobile_no = @mobile_no where" +
                    " email = @email and password = @password";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@first_name", first_name);
                command.Parameters.AddWithValue("@last_name", last_name);
                command.Parameters.AddWithValue("@address", address);
                command.Parameters.AddWithValue("@role", role);
                command.Parameters.AddWithValue("@password", password);
                command.Parameters.AddWithValue("@mobile_no", mobile_no);
                command.Parameters.AddWithValue("@email", email);

                int affectedRows = command.ExecuteNonQuery();
                if(affectedRows > 0)
                {
                    status = true;
                }

            }
            catch(Exception ee)
            {
                throw ee;
            }
            finally
            {
                await connection.CloseAsync();
            }
            return status;
        }
    }
}
