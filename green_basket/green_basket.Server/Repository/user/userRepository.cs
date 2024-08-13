using green_basket.Server.Entities;
using green_basket.Server.Repository.user.Interface;
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace green_basket.Server.Repository.user
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public UserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = this._configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<List<User>> Getall()
        {
            List<User> users = new List<User>();
            MySqlConnection connection = new MySqlConnection(_connectionString);

            try
            {
                string query = "SELECT * FROM user";
                MySqlCommand command = new MySqlCommand(query, connection);
                await connection.OpenAsync();

                using (MySqlDataReader reader = (MySqlDataReader)await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        int userId = int.Parse(reader["user_Id"].ToString());
                        string? firstName = reader["first_name"].ToString();
                        string? lastName = reader["last_name"].ToString();
                        string? email = reader["email"].ToString();
                        string? password = reader["password"].ToString();
                        string? address = reader["address"].ToString();
                        string? mobileNo = reader["mobile_no"].ToString();
                        string? roleString = reader["role"].ToString();

                        Role role;
                        if (!Enum.TryParse(roleString, out role))
                        {
                            role = Role.Customer; // Default to Customer if parsing fails
                        }

                        User currentUser = new User()
                        {
                            user_Id = userId,
                            first_name = firstName,
                            last_name = lastName,
                            email = email,
                            password = password,
                            address = address,
                            mobile_no = mobileNo,
                            role = role,
                        };

                        users.Add(currentUser);
                    }
                }
            }
            catch (Exception ex)
            {
                // You can log the exception here if needed
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
                string query = "insert into user (first_name,last_name,address,role,password,email,mobile_no)" +
                    "  values(@first_name,@last_name,@address,@role,@password,@email,@mobile_no)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@first_name", user.first_name);
                command.Parameters.AddWithValue("@last_name", user.last_name);
                command.Parameters.AddWithValue("@address", user.address);
                command.Parameters.AddWithValue("@role", user.role.ToString());
                command.Parameters.AddWithValue("@password", user.password);
                command.Parameters.AddWithValue("@email", user.email);
                command.Parameters.AddWithValue("@mobile_no", user.mobile_no);

                await connection.OpenAsync();
                int rowsaffected = await command.ExecuteNonQueryAsync();
                if(rowsaffected > 0)
                {
                    status = true;
                }
            }
            catch(Exception ex)
            {
                throw new Exception("An error occured while inserting the user.", ex);
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
                command.Parameters.AddWithValue("@first_name", user.first_name);
                command.Parameters.AddWithValue("@last_name", user.last_name);
                command.Parameters.AddWithValue("@address", user.address);
                command.Parameters.AddWithValue("@role", user.role.ToString());
                command.Parameters.AddWithValue("@password", user.password);
                command.Parameters.AddWithValue("@mobile_no", user.mobile_no);
                command.Parameters.AddWithValue("@email", user.email);

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

        public async Task<bool> Delete(string email)
        {
            bool status = false;
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = _connectionString;
            try
            {
                string query = "delete from user where email=@email";
                MySqlCommand command = new MySqlCommand(query,connection);
                command.Parameters.AddWithValue("@email", email);
                await connection.OpenAsync();
                int rowsAffected= command.ExecuteNonQuery();
                if(rowsAffected > 0)
                {
                    status = true;
                }
            }
            catch(Exception e)
            {
                throw new Exception("Error while deleteing the user.", e);
            }
            finally
            {
                await connection.CloseAsync();
            }
            return status;
        }

        public async Task<User> Login(string email, string password)
        {
            User? user = null;
            MySqlConnection connection = new MySqlConnection(_connectionString);

            try
            {
                // SQL query to select the user where the email and password match
                string query = "SELECT * FROM user WHERE email = @email AND password = @password";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@password", password);

                await connection.OpenAsync();

                using (MySqlDataReader reader = (MySqlDataReader)await command.ExecuteReaderAsync())
                {
                    // If a match is found, populate the user object
                    if (await reader.ReadAsync())
                    {
                        user = new User
                        {
                            user_Id = int.Parse(reader["user_Id"].ToString()),
                            first_name = reader["first_name"].ToString(),
                            last_name = reader["last_name"].ToString(),
                            email = reader["email"].ToString(),
                            password = reader["password"].ToString(),
                            address = reader["address"].ToString(),
                            mobile_no = reader["mobile_no"].ToString(),
                            role = Enum.TryParse(reader["role"].ToString(), out Role role) ? role : Role.Customer,
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while logging in.", ex);
            }
            finally
            {
                await connection.CloseAsync();
            }

            return user;
        }

    }

}
