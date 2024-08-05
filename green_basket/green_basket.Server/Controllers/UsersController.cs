using green_basket.Server.Entities;
using green_basket.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace green_basket.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public UsersController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //[HttpPost]
        //[Route("registration")]
        //public Response Register(User user)
        //{
        //    Response response = new Response();
        //    UserDAL userDAL = new UserDAL();
        //    SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("green_basket").ToString());
        //    response=userDAL.register(user, connection);
        //    return response;
        //}

        //[HttpPost]
        //[Route("login")]
        //public Response Login(User user)
        //{
        //    Response response = new Response();
        //    UserDAL userDAL = new UserDAL();
        //    SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("").ToString());
        //    response=userDAL.Login(user, connection);
        //    return response;
        //}
    }
}
