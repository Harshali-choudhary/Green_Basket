using green_basket.Server.Entities;
using green_basket.Server.Service.CurrentUserSessionService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace green_basket.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] 
    public class CurrentUserSessionController : ControllerBase
    {
        private readonly ICurrentUserSession _currentUserSession;

        public CurrentUserSessionController(ICurrentUserSession currentUserSession)
        {
            _currentUserSession = currentUserSession;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var sessions = await _currentUserSession.getAll();
                return Ok(new { Success = true, Data = sessions });
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, new { Success = false, Message = "Internal server error" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] Current_User_Session user_Session)
        {
            if (user_Session == null)
            {
                return BadRequest(new { Success = false, Message = "Invalid session data." });
            }

            try
            {
                bool status = await _currentUserSession.Insert(user_Session);
                if (status)
                {
                    return CreatedAtAction(nameof(GetAll), new { id = user_Session.Id }, new { Success = true, Data = user_Session });
                }
                else
                {
                    return BadRequest(new { Success = false, Message = "Failed to insert session." });
                }
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, new { Success = false, Message = "Internal server error" });
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Current_User_Session current_User_Session)
        {
            if (current_User_Session == null)
            {
                return BadRequest(new { Success = false, Message = "Invalid session data." });
            }

            try
            {
                bool status = await _currentUserSession.Update(current_User_Session);
                if (status)
                {
                    return NoContent();
                }
                else
                {
                    return NotFound(new { Success = false, Message = "Session not found." });
                }
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, new { Success = false, Message = "Internal server error" });
            }
        }

        [HttpDelete("{Cid}")]
        public async Task<IActionResult> Delete(int Cid)
        {
            try
            {
                bool status = await _currentUserSession.Delete(Cid);
                if (status)
                {
                    return NoContent();
                }
                else
                {
                    return NotFound(new { Success = false, Message = "Session not found." });
                }
            }
            catch (Exception ex)
            {
               
                return StatusCode(500, new { Success = false, Message = "Internal server error" });
            }
        }
    }
}
