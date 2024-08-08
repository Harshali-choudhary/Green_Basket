using green_basket.Server.Entities;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;

namespace green_basket.Server.Repository.current_user_session
{
    public class CurrentUserSessionRepo : ICurrentUserSessionRepo
    {
        private readonly IConfiguration _configuration;

        private readonly string _connectionString;

        public CurrentUserSessionRepo(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = this._configuration.GetConnectionString("DefaultConnection");
        }
        public async Task<bool> Delete(int Cid)
        {
            bool status = false;
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = _connectionString;
            try
            {
                string query = "Delete from Current_User_Session where Id=@Cid";
                await connection.OpenAsync();
                MySqlCommand command =new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Cid", Cid);
                int affectedRows = await command.ExecuteNonQueryAsync();
                if (affectedRows > 0)
                {
                    status = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An Error occured while deleting the User", ex);
            }
            finally
            {
               await connection.CloseAsync();
            }
            return status;
        }

        public async Task<List<Current_User_Session>> getAll()
        {
            List<Current_User_Session> CList = new List<Current_User_Session>();
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = _connectionString;
            try
            {
                string query = "select * from Current_User_Session";
                await connection.OpenAsync();
                MySqlCommand command = new MySqlCommand(query, connection);
                using(MySqlDataReader reader = (MySqlDataReader) await command.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        int Cid = int.Parse(reader["Id"].ToString());
                        int Uid = int.Parse(reader["user_Id"].ToString());
                        string? Crole = reader["role"].ToString();
                        DateTime Cdate = DateTime.Parse(reader["datetime"].ToString());

                        Role role;
                        if(!Enum.TryParse(Crole,out role))
                        {
                            role = Role.Customer;
                        }

                        Current_User_Session current_user = new Current_User_Session()
                        {
                            Id = Cid,
                            user_Id = Uid,
                            role = role,
                            dateTime = Cdate,
                        };
                        CList.Add(current_user);
                    }
                }
            }
            catch(Exception ee)
            {
                throw new Exception("An Error Occured while deleting the Error.", ee);
            }
            finally
            {
                await connection.CloseAsync();
            }
            return CList;
        }

        public async Task<bool> Insert(Current_User_Session session)
        {
            bool status = false;
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString =  _connectionString;
            try
            {
                string query = "insert into Current_User_Session(user_id,Role,DateTime) values(@user_Id,@role,@dateTime)";
                await connection.OpenAsync();
                MySqlCommand cmd = new MySqlCommand(query,connection);
                cmd.Parameters.AddWithValue("@user_Id", session.user_Id);
                cmd.Parameters.AddWithValue("@role", session.role);
                cmd.Parameters.AddWithValue("@dateTime", session.dateTime);
                int affectedRows = await cmd.ExecuteNonQueryAsync();
                if(affectedRows > 0)
                {
                    status=true;
                }
            }
            catch(Exception exec)
            {
                throw new Exception("An Error occured while inserting the data.", exec);
            }
            finally
            {
                await connection.CloseAsync();
            }
            return status;
        }

        public async Task<bool> Update(Current_User_Session session)
        {
            bool status = false;
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = _connectionString;
            try
            {
                string query = "Update Current_User_Session set Role=@role,DateTime=@dateTime where Id =@Cid";
                await connection.OpenAsync();
                MySqlCommand cmd = new MySqlCommand(query,connection);
                cmd.Parameters.AddWithValue("@role", session.role);
                cmd.Parameters.AddWithValue("@dateTime", session.dateTime);
                cmd.Parameters.AddWithValue("Cid", session.Id);

                int affectedRows = await cmd.ExecuteNonQueryAsync();
                if(affectedRows > 0)
                {
                    status = true;
                }

            }
            catch(Exception ex)
            {
                throw new Exception("An Error Occurred while updating the details.", ex);
            }
            finally
            {
               await connection.CloseAsync();
            }
            return status;
        }
    }
}
