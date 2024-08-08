using green_basket.Server.Entities;
using green_basket.Server.Service.CurrentUserSessionService;
using Microsoft.AspNetCore.Mvc;

namespace green_basket.Server.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class CurrentUserSessionController : Controller
    {
       private readonly ICurrentUserSession _currentUserSession;

        public CurrentUserSessionController(ICurrentUserSession currentUserSession)
        {
            _currentUserSession = currentUserSession;
        }

        [HttpGet]
        public async Task<List<Current_User_Session>> GetAll()
        {
            List<Current_User_Session> Clist = await _currentUserSession.getAll();
            return Clist;
        }

        [HttpPost]
        public async Task<bool> Insert(Current_User_Session user_Session)
        {
            bool status = await _currentUserSession.Insert(user_Session);
            return status;
        }

        [HttpPut]
        public async Task<bool> Update(Current_User_Session current_User_Session)
        {
            bool status = await _currentUserSession.Update(current_User_Session);
            return status;
        }

        [HttpDelete]
        public async Task<bool> Delete(int Cid)
        {
            bool status = await _currentUserSession.Delete(Cid);
            return status;
        }
    }
}
