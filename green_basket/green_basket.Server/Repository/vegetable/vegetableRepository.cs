using green_basket.Server.Entities;
using green_basket.Server.Repository.vegetable.Interface;
using MySql.Data.MySqlClient;

namespace green_basket.Server.Repository.vegetable
{
    public class vegetableRepository : IVegetableRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public vegetableRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = this._configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<List<Vegetables>> GetAll()
        {
            List<Vegetables> vegetables = new List<Vegetables>();
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = _connectionString;
            try
            {
                string query = "select * from Vegetables";
                MySqlCommand command = new MySqlCommand(query, connection);
                await connection.OpenAsync();
                MySqlDataReader reader = command.ExecuteReader();
                while (await reader.ReadAsync())
                {
                    int vegetable_id = int.Parse(reader["vegetable_id"].ToString());
                    string image_url = reader["image_url"].ToString();
                    string name = reader["name"].ToString();
                    decimal price = decimal.Parse(reader["price"].ToString());
                    int quantity = int.Parse(reader["quantity"].ToString());

                    Vegetables vegetable = new Vegetables()
                    {
                        vegetable_id = vegetable_id,
                        image_url = image_url,
                        vegetable_name = name,
                        vegetable_price = price,
                        quantity = quantity
                    };
                    vegetables.Add(vegetable);
                }
                await reader.CloseAsync();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                await connection.CloseAsync();
            }
            return vegetables;
        }

        public async Task<bool> Delete(int id)
        {
            bool status=false;
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString=_connectionString;
            try
            {
                string query = "delete from vegetables where id=@vegetable_id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("vegetable_id", id);
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

        public async Task<bool> Insert(Vegetables vegetable)
        {
            bool status = false; ;
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = _connectionString;
            try
            {
                string query = "Insert into vegetables (image_url,vegetable_name,vegetable_price,quantity) values(@image_url,@name,@price,@quantity)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@image_url", vegetable.image_url);
                command.Parameters.AddWithValue("@name", vegetable.vegetable_name);
                command.Parameters.AddWithValue("@price", vegetable.vegetable_price);
                command.Parameters.AddWithValue("@quantity", vegetable.quantity);
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
                await connection.CloseAsync() ;
            }
            return status;
        }

        public async Task<bool> Update(Vegetables vegetable)
        {
           bool status= false; 
           MySqlConnection connection = new MySqlConnection();
           connection.ConnectionString = _connectionString;
            try
            {
                string query = "update customers set image_url=@image_url,name=@name,price=@price,quantity=@price where id=@vegetable_id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@vegetable_id", vegetable.vegetable_id);
                command.Parameters.AddWithValue("@vegetable_name", vegetable.vegetable_name);
                command.Parameters.AddWithValue("@vegetable_price", vegetable.vegetable_price);
                command.Parameters.AddWithValue("@quantity", vegetable.quantity);
                await connection.OpenAsync();
                int rowsAffected = command.ExecuteNonQuery();
                {
                    if (rowsAffected > 0)
                    {
                        status = true;
                    }
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


    }
}
   
