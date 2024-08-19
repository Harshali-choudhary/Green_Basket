using green_basket.Server.Entities;
using green_basket.Server.Models;
using green_basket.Server.Service.userService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace green_basket.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var userList = await _userService.Getall();
                return Ok(new { Success = true, Data = userList });
            }
            catch (Exception ex)
            {
                // Log the exception here
                return StatusCode(500, new { Success = false, Message = "Internal server error" });
            }
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> Insert([FromBody] UserDto userDto) // Use DTO for input
        {
            if (userDto == null)
            {
                return BadRequest(new { Success = false, Message = "Invalid user data." });
            }

            try
            {
                var user = new User
                {
                    // Map DTO to User entity
                    first_name = userDto.FirstName,
                    last_name = userDto.LastName,
                    address = userDto.Address,
                    role = userDto.Role,
                    password = userDto.Password, 
                    email = userDto.Email,
                    mobile_no = userDto.MobileNo
                };

                bool status = await _userService.Insert(user);
                if (status)
                {
                    return CreatedAtAction(nameof(GetAll), new { id = user.user_Id }, new { Success = true });
                }
                else
                {
                    return BadRequest(new { Success = false, Message = "Failed to insert user." });
                }
            }
            catch (Exception ex)
            {
                // Log the exception here
                return StatusCode(500, new { Success = false, Message = "Internal server error" });
            }
        }

        [HttpPut("UpdateDetails")]
        public async Task<IActionResult> UpdateDetails([FromBody] UserDto userDto) // Use DTO for input
        {
            if (userDto == null)
            {
                return BadRequest(new { Success = false, Message = "Invalid user data." });
            }

            try
            {
                var user = new User
                {
                    // Map DTO to User entity
                    first_name = userDto.FirstName,
                    last_name = userDto.LastName,
                    address = userDto.Address,
                    role = userDto.Role,
                    password = userDto.Password, // Hash password before saving
                    email = userDto.Email,
                    mobile_no = userDto.MobileNo
                };

                bool status = await _userService.UpdateDetails(user);
                if (status)
                {
                    return NoContent(); // 204 No Content for successful update
                }
                else
                {
                    return NotFound(new { Success = false, Message = "User not found." });
                }
            }
            catch (Exception ex)
            {
                // Log the exception here
                return StatusCode(500, new { Success = false, Message = "Internal server error" });
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromQuery] string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return BadRequest(new { Success = false, Message = "Email is required." });
            }

            try
            {
                bool status = await _userService.Delete(email);
                if (status)
                {
                    return NoContent();
                }
                else
                {
                    return NotFound(new { Success = false, Message = "User not found." });
                }
            }
            catch (Exception ex)
            {
                // Log the exception here
                return StatusCode(500, new { Success = false, Message = "Internal server error" });
            }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDto)
        {
            if (loginDto == null || string.IsNullOrEmpty(loginDto.Email) || string.IsNullOrEmpty(loginDto.Password))
            {
                return BadRequest(new { Success = false, Message = "Email and password are required." });
            }

            try
            {
                // Attempt to authenticate the user
                var user = await _userService.Login(loginDto.Email, loginDto.Password);

                if (user != null)
                {
                    // Assuming 'user' has properties like 'Role' and 'Token'
                    return Ok(new
                    {
                        Success = true,
                        Data = new
                        {
                            user.user_Id,
                            user.email,
                            user.role // Include role information
                        }
                    });
                }
                else
                {
                    return Unauthorized(new { Success = false, Message = "Invalid email or password." });
                }
            }
            catch (Exception ex)
            {
                // Log the exception here (you might use a logging framework like Serilog, NLog, etc.)
                return StatusCode(500, new { Success = false, Message = "Internal server error" });
            }
        }

    }
}
