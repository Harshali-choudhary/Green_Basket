using green_basket.Server.Entities;
using green_basket.Server.Service.CartVegetableService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace green_basket.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartVegetableController : ControllerBase
    {
        private readonly ICartVegetableService _service;

        public CartVegetableController(ICartVegetableService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var vegetables = await _service.GetAll();
                return Ok(new { Success = true, Data = vegetables });
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, new { Success = false, Message = "Internal server error" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] Cart_Vegetables vegetables)
        {
            if (vegetables == null)
            {
                return BadRequest(new { Success = false, Message = "Invalid cart vegetable data." });
            }

            try
            {
                bool result = await _service.Insert(vegetables);
                if (result)
                {
                    return CreatedAtAction(nameof(GetAll), new { id = vegetables.vcart_id }, new { Success = true, Data = vegetables });
                }
                else
                {
                    return BadRequest(new { Success = false, Message = "Failed to insert cart vegetable." });
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, new { Success = false, Message = "Internal server error" });
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Cart_Vegetables vegetables)
        {
            if (vegetables == null)
            {
                return BadRequest(new { Success = false, Message = "Invalid cart vegetable data." });
            }

            try
            {
                bool result = await _service.Update(vegetables);
                if (result)
                {
                    return NoContent(); // 204 No Content for successful update
                }
                else
                {
                    return NotFound(new { Success = false, Message = "Cart vegetable not found." });
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, new { Success = false, Message = "Internal server error" });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                bool result = await _service.Delete(id);
                if (result)
                {
                    return NoContent(); // 204 No Content for successful delete
                }
                else
                {
                    return NotFound(new { Success = false, Message = "Cart vegetable not found." });
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, new { Success = false, Message = "Internal server error" });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                var vegetable = await _service.GetById(id);
                if (vegetable != null)
                {
                    return Ok(new { Success = true, Data = vegetable });
                }
                else
                {
                    return NotFound(new { Success = false, Message = "Cart vegetable not found." });
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, new { Success = false, Message = "Internal server error" });
            }
        }
    }
}
