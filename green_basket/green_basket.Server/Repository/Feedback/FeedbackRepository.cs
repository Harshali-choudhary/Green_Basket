using green_basket.Server.Entities;
using green_basket.Server.Repository.Feedback.Interface;
using MySql.Data.MySqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace green_basket.Server.Repository.Feedback
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public FeedbackRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        

    public async Task<bool> Delete(int id)
        {
            bool status = false;
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = _connectionString;
            try
            {
                
                string query = "delete from Feedback where fid = @fid";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("fid", id);
                await connection.OpenAsync();
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    status = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                await connection.CloseAsync();
            }
            return status;
        }

        public async Task<List<Feedbacks>> GetAll()
        {
            List<Feedbacks> feedbacks = new List<Feedbacks>();
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = _connectionString;
            try
            {
                string query = "select * from Feedback";
                MySqlCommand command = new MySqlCommand(query, connection);
                await connection.OpenAsync();
                MySqlDataReader reader = command.ExecuteReader();
                while (await reader.ReadAsync())
                {
                    int id = int.Parse(reader["fid"].ToString());
                    int vid = int.Parse(reader["vegetable_id"].ToString());
                    int uid = int.Parse(reader["user_id"].ToString());
                    int rating = int.Parse(reader["rating"].ToString());
                    string comment = reader["comment"].ToString();

                    Feedbacks feedback = new Feedbacks()
                    {
                        fid = id,
                        vegetable_id = vid,
                        user_Id = uid,
                        rating = rating,
                        comments = comment,
                    };
                    feedbacks.Add(feedback);
                }
                await connection.CloseAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                await connection.CloseAsync();
            }
            return feedbacks;

        }

        public async Task<bool> Insert(Feedbacks feedback)
        {
            bool status = false;
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = _connectionString;
            try
            {
                string query = "Insert into Feedback(vegetable_id,user_id,rating,comment) VALUES(@vegetable_id,@user_id,@rating,@comment)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@vegetable_id", feedback.vegetable_id);
                command.Parameters.AddWithValue("@user_id", feedback.user_Id);
                command.Parameters.AddWithValue("@rating", feedback.rating);
                command.Parameters.AddWithValue("@comment", feedback.comments);
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    status = true;

                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                await connection.CloseAsync();
            }
            return status;

        }

        public async Task<bool> Update(Feedbacks feedback)
        {
            bool status = false;
            using (var connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    string query = "UPDATE Feedback SET vegetable_id = @vid, user_id = @uid, rating = @rating, comment = @comment WHERE fid = @fid";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@fid", feedback.fid);
                        command.Parameters.AddWithValue("@vid", feedback.vegetable_id); // corrected parameter name
                        command.Parameters.AddWithValue("@uid", feedback.user_Id); // corrected parameter name
                        command.Parameters.AddWithValue("@rating", feedback.rating);
                        command.Parameters.AddWithValue("@comment", feedback.comments);

                        await connection.OpenAsync();
                        int rowsAffected = await command.ExecuteNonQueryAsync(); // added 'await'

                        status = rowsAffected > 0;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    await connection.CloseAsync();
                }
            }
            return status;
        }

    }
}
    
