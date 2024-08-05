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
                    decimal price = decimal.Parse(reader["price"].ToString();
                    int quanitity = int.Parse(reader["quantity"].ToString());

                    vegetables vegetable = new vegetables(
                        this.vegetable_id = vegetable_id;
                    this.image_url = image_url;
                    this.name = name;
                    this.price = price;
                    this.quantity = quantity;
                }
                Vegetables.add(vegetable);
            }
            await reader.CloseAsync();
        }
catch (Exception){
            throw
         }
finally{
    await connection.CloseAsync();
    }
return Vegetables;
    }
}
