using green_basket.Server.Entities;
using green_basket.Server.Repository.Cart_Vegetable.Interface;
using MySql.Data.MySqlClient;

namespace green_basket.Server.Repository.Cart_Vegetable
{
    public class CartVegetableRepository : ICartVegetablesRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public CartVegetableRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = this._configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<List<Cart_Vegetables>> GetAll()
        {
            List<Cart_Vegetables> list = new List<Cart_Vegetables>();
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = _connectionString;
            try
            {
                string query = "select * from cart_vegetable";
                MySqlCommand command = new MySqlCommand(query, connection);
                await connection.OpenAsync();
                MySqlDataReader reader = command.ExecuteReader();
                while (await reader.ReadAsync())
                {
                    int id = int.Parse(reader["vcart_id"].ToString());
                    int vegeid = int.Parse(reader["vegetable_id"].ToString()) ;
                    

                    Cart_Vegetables vegetables = new Cart_Vegetables()
                    {
                        vcart_id = id, 
                        vegetable_id = vegeid,
                        
                    };
                    list.Add(vegetables);
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
            return list;
        }
        public async Task<bool> Insert(Cart_Vegetables vegetables)
        {
            bool status = false;
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = _connectionString;
            try
            {
                string query = "Insert into cart_vegetable(vegetable_id) VALUES(@vegetable_id)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@vegetable_id", vegetables.vegetable_id);
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

        public async Task<bool> Update(Cart_Vegetables vegetables)
        {
            bool status = false;
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = _connectionString;
            try
            {
                string query = "update cart_vegetable set vegetable_id=@vegetable_id where vcart_id=@vcart_id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@vcart_id",vegetables.vcart_id);
                command.Parameters.AddWithValue("@vegetable_id", vegetables.vegetable_id);
               
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
        public async Task<bool> Delete(int id)
        {
            bool status = false;
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = _connectionString;
            try
            {
                string query = "delete from cart_vegetable where vcart_id=@id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("id",id);
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

        public async Task<Cart_Vegetables> GetById(int id)
        {
            Cart_Vegetables vegetable = null;
            using MySqlConnection connection = new MySqlConnection(_connectionString);
            try
            {
                string query = "SELECT * FROM cart_vegetable WHERE vcart_id = @id";
                using MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                await connection.OpenAsync();
                using (MySqlDataReader reader =(MySqlDataReader) await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        int vegeId = int.Parse(reader["vegetable_id"].ToString());

                        vegetable = new Cart_Vegetables()
                        {
                            vcart_id = id,
                            vegetable_id = vegeId,
                        };
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return vegetable;
        }
    }
}
