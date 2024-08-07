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
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = _connectionString;
            try
            {
                string query = "select * from user";
                MySqlCommand command = new MySqlCommand(query, connection);
                await connection.OpenAsync();
                using (MySqlDataReader reader = (MySqlDataReader)await command.ExecuteReaderAsync())
                {
                    int user_Id = int.Parse(reader["user_Id"].ToString());
                    string? first_name = reader["first_name"].ToString();
                    string? last_name = reader["last_name"].ToString();
                    string? email = reader["email"].ToString();
                    string? password = reader["password"].ToString();
                    string? address = reader["address"].ToString();
                    string? mobile_no = reader["mobile_no"].ToString();
                    string? role = reader["role"].ToString(); ;

                    User user = new User();

                    while (await reader.ReadAsync())

                    {
                        int UserId = int.Parse(reader["user_Id"].ToString());
                        string? FirstName = reader["first_name"].ToString();
                        string? LastName = reader["last_name"].ToString();
                        string? Email = reader["email"].ToString();
                        string? Password = reader["password"].ToString();
                        string? Address = reader["address"].ToString();
                        string? MobileNo = reader["mobile_no"].ToString();
                        string? roleString = reader["role"].ToString();

                        Role roles;
                        if(!Enum.TryParse(roleString,out roles))
                        {
                            roles = Role.Customer;
                        }

                        User currentuser = new User()
                        {
                            user_Id = UserId,
                            first_name = FirstName,
                            last_name = LastName,
                            email = Email,
                            password = Password,
                            address = Address,
                            mobile_no = MobileNo,
                            role = roles,
                        };
                        users.Add(currentuser);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
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
    }
}
