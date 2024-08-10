using green_basket.Server.Entities;
using green_basket.Server.Repository.Cart.Interface;
using green_basket.Server.Repository.Cart_Vegetable.Interface;
using MySql.Data.MySqlClient;

namespace green_basket.Server.Repository.Cart
{
    public class CartOrderRepository : ICartOrderRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public CartOrderRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = this._configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<bool> Delete(int id)
        {
            bool status = false;
            MySqlConnection connection = new MySqlConnection(); 
            connection.ConnectionString = _connectionString;
            try
            {
                string query = "delete from cart_order where cart_id = @id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("id", id);
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

        public async Task<List<Cart_Order>> GetAll()

        {
            List<Cart_Order> Lcart_Orders = new List<Cart_Order>();
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = _connectionString;
            try
            {
                string query = "select * from cart_order";
                MySqlCommand command = new MySqlCommand(query, connection);
                await connection.OpenAsync();
                MySqlDataReader reader = command.ExecuteReader();
                while (await reader.ReadAsync())
                {
                    int cid = int.Parse(reader["cart_id"].ToString());
                    int oid = int.Parse(reader["order_id"].ToString());

                    Cart_Order cart_Order = new Cart_Order()
                    {
                        Ocart_Id = cid,
                        order_Id = oid,
                    };
                    Lcart_Orders.Add(cart_Order);
                    
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
            return Lcart_Orders;
        }

        public async Task<bool> Insert(Cart_Order cart_Order)
        {
            bool status = false;
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = _connectionString;
            try
            {
                string query = "Insert into cart_order (order_id) VALUES(@order_id)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@order_id", cart_Order.order_Id);
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                if(rowsAffected>0)
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
        public async Task<bool> Update(Cart_Order cart_Order)
        {
            bool status = false;
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString= _connectionString;
            try
            {
                string query = "Update cart_order set order_id=@order_id where cart_id = @cart_id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@cart_id", cart_Order.Ocart_Id);
                command.Parameters.AddWithValue("@order_id", cart_Order.order_Id);
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
