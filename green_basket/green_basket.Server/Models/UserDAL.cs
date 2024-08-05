//using green_basket.Server.Entities;
//using System.Data;
//using System.Data.SqlClient;

//namespace green_basket.Server.Models
//{
//    public class UserDAL
//    {
//        public Response register(User user,SqlConnection connection)
//        {
//            Response response = new Response();
//            SqlCommand cmd = new SqlCommand("sp_register",connection);
//            cmd.CommandType = System.Data.CommandType.StoredProcedure;
//            cmd.Parameters.AddWithValue("@first_name",user.first_name);
//            cmd.Parameters.AddWithValue("@last_name", user.last_name);
//            cmd.Parameters.AddWithValue("@address", user.address);
//            cmd.Parameters.AddWithValue("@role", user.role);
//            cmd.Parameters.AddWithValue("@password", user.password);
//            cmd.Parameters.AddWithValue("@email", user.email);
//            cmd.Parameters.AddWithValue("@mobile_no", user.mobile_no);
//            connection.Open();
//            int i = cmd.ExecuteNonQuery();
//            connection.Close();
//            if(i>0)
//            {
//                response.statusCode = 200;
//                response.StatusMessage = "User Registered Successfully";
//            }
//            else
//            {
//                response.statusCode = 100;
//                response.StatusMessage = "User Registration failed";
//            }
//            return response;
//        }

//        public Response Login(User user, SqlConnection connection)
//        {
//            Response response = new Response();
//            try
//            {
//                // Open the connection if it's not already open
//                if (connection.State != System.Data.ConnectionState.Open)
//                {
//                    connection.Open();
//                }
//                using (SqlCommand cmd = new SqlCommand("sp_login", connection))
//                {
//                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
//                    cmd.Parameters.AddWithValue("@email", user.email);
//                    cmd.Parameters.AddWithValue("@password", user.password);

//                    // Execute the command and read the results
//                    using (SqlDataReader reader = cmd.ExecuteReader())
//                    {
//                        if (reader.HasRows)
//                        {
//                            response.statusCode = 200;
//                            response.StatusMessage = "Login successfully";
//                        }
//                        else
//                        {
//                            response.statusCode = 100;
//                            response.StatusMessage = "Invalid EmailId and Password";
//                        }

//                    }

//                }

//            }        
//            catch(Exception ex)
//            {
//                response.statusCode = 500;
//                response.StatusMessage = "An error occured" + ex.Message;
//            }
//            finally
//            {
//                if(connection.State != System.Data.ConnectionState.Closed)
//                {
//                    connection.Close();
//                }
//            }
                     
//            return response;
//        }
//    }
//}
