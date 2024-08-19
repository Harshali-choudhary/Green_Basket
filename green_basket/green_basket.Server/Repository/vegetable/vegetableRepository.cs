using green_basket.Server.Entities;
using green_basket.Server.Repository.vegetable.Interface;
using MySql.Data.MySqlClient;

namespace green_basket.Server.Repository.vegetable
{
    public class VegetableRepository : IVegetableRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public VegetableRepository(IConfiguration configuration)
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
                    int Vegetable_id = int.Parse(reader["vegetable_id"].ToString());
                    string Image_url = reader["image_url"].ToString();
                    string Name = reader["name"].ToString();
                    decimal Price = decimal.Parse(reader["price"].ToString());
                    int Quantity = int.Parse(reader["quantity"].ToString());

                    Vegetables vegetable = new Vegetables()
                    {
                        vegetable_id = Vegetable_id,
                        image_url = Image_url,
                        vegetable_name = Name,
                        vegetable_price = Price,
                        quantity = Quantity
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
                string query = "delete from vegetables where vegetable_id = @id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
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
                string query = "Insert into vegetables (image_url,name,price,quantity) values(@image_url,@name,@price,@quantity)";
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
                string query = "update vegetables set image_url=@image_url,name=@name,price=@price,quantity=@price where vegetable_id=@vegetable_id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@vegetable_id", vegetable.vegetable_id);
                command.Parameters.AddWithValue("@image_url", vegetable.image_url);
                command.Parameters.AddWithValue("@name", vegetable.vegetable_name);
                command.Parameters.AddWithValue("@price", vegetable.vegetable_price);
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

        public async Task<Vegetables> GetById(int id)
        {
            Vegetables vegetable = null;
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = _connectionString;
            try
            {
                string query = "select * from Vegetables where vegetable_id=@id";
                MySqlCommand command = new MySqlCommand(query, connection);
                await connection.OpenAsync();
                command.Parameters.AddWithValue("@vegetable_id", id);
                MySqlDataReader reader = command.ExecuteReader();
                while (await reader.ReadAsync())
                {
                    vegetable = new Vegetables
                    {
                        vegetable_id = reader.GetInt32("vegetable_id"),
                        image_url = reader.GetString("image_url"),
                        vegetable_name = reader.GetString("vegetable_name"),
                        vegetable_price = reader.GetDecimal("vegetable_price"),
                        quantity = reader.GetInt32("quantity")
                    };
                   
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
            return vegetable;
        }

    }
}
   
