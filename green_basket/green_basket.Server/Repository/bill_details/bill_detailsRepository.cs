using green_basket.Server.Entities;
using MySql.Data.MySqlClient;


namespace green_basket.Server.Repository.bill_details
{
    public class bill_detailsRepository : IBillDetailsRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string connectionString;

        public bill_detailsRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = this._configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<bool> Delete(int billId)
        {
            bool status=false;
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = connectionString;
            try
            {
                string query = "Delete from bill_details where bill_id=@billId";
                await connection.OpenAsync();
                MySqlCommand cmd = new MySqlCommand(query,connection);
                cmd.Parameters.AddWithValue("@billId", billId);
                int affectedRows = await cmd.ExecuteNonQueryAsync();
                if (affectedRows > 0)
                {
                    status = true;
                }
            }
            catch(Exception ee)
            {
                throw new Exception("An Error occured while deleting", ee);
            }
            finally
            {
                await connection.CloseAsync();
            }
            return status;
        }

        public async Task<List<BillDetails>> GetAll()
        {
            List<BillDetails> list = new List<BillDetails>();
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = connectionString;
            try
            {
                string query = "select * from bill_details";
                await connection.OpenAsync();
                MySqlCommand cmd = new MySqlCommand(query,connection);
                using (MySqlDataReader reader = (MySqlDataReader) await cmd.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        int Bill_id = int.Parse(reader["bill_id"].ToString());
                        int User_id = int.Parse(reader["user_id"].ToString());
                        int Order_id = int.Parse(reader["order_id"].ToString());
                        DateTime Transaction_Date = DateTime.Parse(reader["transaction_date"].ToString());
                        string? Transaction_mode = reader["transaction_mode"].ToString();
                        string? Transaction_status = reader["transaction_status"].ToString();

                        TransactionMode mode;
                        TransactionStatus status;

                        if (!Enum.TryParse(Transaction_mode, out mode))
                        {
                            mode = TransactionMode.UPI; 
                        }

                        if (!Enum.TryParse(Transaction_status, out status))
                        {
                            status = TransactionStatus.Pending; 
                        }
                        BillDetails bill = new BillDetails()
                        {
                            bill_id = Bill_id,
                            user_id = User_id,
                            order_Id = Order_id,
                            transactonDate = Transaction_Date,
                            transactionMode = mode,
                            status = status,

                        };
                        list.Add(bill);
                    }
                }
            }
            catch(Exception e)
            {
                throw new Exception("Error occured while getting the all bills", e);
            }
            finally
            {
                await connection.CloseAsync();
            }
            return list;
        }

        public async Task<bool> Insert(BillDetails bill)
        {
            bool status = false;
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = connectionString;
            try
            {
                string query = "insert into bill_details(user_id,order_id,transaction_date,transaction_mode,transaction_status)" +
                    " values(@user_id,@order_id,@transaction_date,@transaction_mode,@transaction_status)";
                await connection.OpenAsync();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@user_id", bill.user_id);
                cmd.Parameters.AddWithValue("@order_id", bill.order_Id);
                cmd.Parameters.AddWithValue("@transaction_date", bill.transactonDate);
                cmd.Parameters.AddWithValue("@transaction_mode", bill.transactionMode);
                cmd.Parameters.AddWithValue("@transaction_status", bill.status);
                int affectedRows = await cmd.ExecuteNonQueryAsync();
                if(affectedRows > 0)
                {
                    status = true;
                }
            }
            catch(Exception e)
            {
                throw new Exception("An Error occured while inserting the details.", e);
            }
            finally
            {
                await connection.CloseAsync();
            }
            return status;
        }

        public async Task<bool> Update(BillDetails bill)
        {
            bool status = false;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    string query = "UPDATE bill_details SET user_id=@user_id, order_id=@order_id, transaction_date=@transaction_date, " +
                        "transaction_mode=@transaction_mode, transaction_status=@transaction_status WHERE bill_id=@bill_id";

                    await connection.OpenAsync();

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        
                        command.Parameters.AddWithValue("@user_id", bill.user_id);
                        command.Parameters.AddWithValue("@order_id", bill.order_Id);
                        command.Parameters.AddWithValue("@transaction_date", bill.transactonDate);
                        command.Parameters.AddWithValue("@transaction_mode", bill.transactionMode.ToString()); 
                        command.Parameters.AddWithValue("@transaction_status", bill.status.ToString()); 
                        command.Parameters.AddWithValue("@bill_id", bill.bill_id);

                        int affectedRows = await command.ExecuteNonQueryAsync();
                        if (affectedRows > 0)
                        {
                            status = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error occurred while updating the details.", ex);
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
