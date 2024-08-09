using green_basket.Server.Entities;
using MySql.Data.MySqlClient;

namespace green_basket.Server.Repository.order
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public OrderRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = this._configuration.GetConnectionString("DefaultConnection");
        }

        async Task<bool> IOrderRepository.DeleteOrder(int order_id)
        {
            bool status = false;
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = _connectionString;
            try
            {
                string query = "delete from orders where order_id=@order_id";
                MySqlCommand cmd = new MySqlCommand(query,connection);
                await connection.OpenAsync();
                cmd.Parameters.AddWithValue("@order_id", order_id);
                int affectedRows = cmd.ExecuteNonQuery();
                if(affectedRows >0)
                {
                    status = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while deleting the order", ex);
            }
            finally
            {
                connection.CloseAsync();
            }
            return status;
        }

        async Task<List<Orders>> IOrderRepository.GetAllOrders()
        {
            List<Orders> orderList = new List<Orders>();
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = _connectionString;
            try
            {
                string query = "select * from orders;";
                MySqlCommand cmd = new MySqlCommand(query,connection);
                await connection.OpenAsync();
                using (MySqlDataReader reader = (MySqlDataReader)await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        int Order_id = int.Parse(reader["order_id"].ToString());
                        int User_id = int.Parse(reader["user_id"].ToString());
                        string Orderstatus = reader["status"].ToString();
                        DateTime Order_date = DateTime.Parse(reader["order_date"].ToString());
                        DateTime Shipping_date = DateTime.Parse(reader["shipping_date"].ToString());
                        string Address = reader["shipping_address"].ToString();
                        Decimal TotalAmount = decimal.Parse(reader["total_amount"].ToString());
                        Status status;
                        if (!Enum.TryParse(Orderstatus, out status))
                        {
                            status = Status.Pending;
                        }
                        Orders o = new Orders()
                        {
                            order_id = Order_id,
                            user_id = User_id,
                            order_date = Order_date,
                            shipping_address = Address,
                            shipping_date = Shipping_date,
                            status = status,
                            total_amount = TotalAmount,
                        };
                        orderList.Add(o);
                    }
                }
            }
            catch(Exception e)
            {
                throw new Exception("An Error occured during fetching the information", e);
            }
            finally
            {
                await connection.CloseAsync();
            }
            return orderList;

        }

        async Task<bool> IOrderRepository.InsertOrder(Orders orders)
        {
            bool result = false;
            MySqlConnection connection = new MySqlConnection();
             connection.ConnectionString =_connectionString;
            await connection.OpenAsync();
            try
            {
                string query = "insert into orders(user_id,status,order_date,shipping_date,shipping_address,total_amount)" +
                    " values(@user_id,@status,@order_date,@shipping_date,@shipping_address,@total_amount)";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@user_id", orders.user_id);
                cmd.Parameters.AddWithValue("@status", orders.status);
                cmd.Parameters.AddWithValue("@order_date", orders.order_date);
                cmd.Parameters.AddWithValue("@shipping_date", orders.shipping_date);
                cmd.Parameters.AddWithValue("@shipping_address", orders.shipping_address);
                cmd.Parameters.AddWithValue("@total_amount", orders.total_amount);

                int affectedRows = await cmd.ExecuteNonQueryAsync();
                if (affectedRows > 0)
                {
                    result = true;
                }
            }
            catch(Exception ee)
            {
                throw new Exception("Error  occured while inserting an Order", ee);
            }
            finally
            {
               await connection.CloseAsync();
            }
            return result;
        }

        async Task<bool> IOrderRepository.UpdateOrder(Orders orders)
        {
            bool status=false;
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = _connectionString;
            await connection.OpenAsync();
            try
            {
                string query = "update orders set user_id=@user_id,status=@status,order_date=@order_date,shipping_date=@shipping_date," +
                    "shipping_address=@shipping_address,total_amount=@total_amount where order_id=@order_id ";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@user_id", orders.user_id);
                command.Parameters.AddWithValue("@status", orders.status);
                command.Parameters.AddWithValue("@order_date", orders.order_date);
                command.Parameters.AddWithValue("@shipping_date", orders.shipping_date);
                command.Parameters.AddWithValue("@shipping_address", orders.shipping_address);
                command.Parameters.AddWithValue("@total_amount", orders.total_amount);
                command.Parameters.AddWithValue("@order_id", orders.order_id);

                int affectedRows = await command.ExecuteNonQueryAsync();
                if(affectedRows > 0)
                {
                    status = true;
                }
            }
            catch(Exception exec)
            {
                throw new Exception("Error occured while updating the order",exec);
            }
            finally
            {
                await connection.CloseAsync();
            }
            return status;
        }
    }
}
