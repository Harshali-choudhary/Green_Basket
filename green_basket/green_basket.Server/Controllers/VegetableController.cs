using green_basket.Server.Entities;
using green_basket.Server.Service.VegetableService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace green_basket.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VegetableController : ControllerBase
    {
        private readonly IVegetableService _service;

        public VegetableController(IVegetableService service)
        {
            _service = service;
        }

        [HttpGet("/GetAllVegetable")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<Vegetables> vegetables = await _service.GetAll();
                return Ok(new { Success = true, Data = vegetables });
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, new { Success = false, Message = "Internal server error" });
            }
        }

        [HttpGet("/id")]
        public async Task<IActionResult> GetById([FromBody] int id)
        {
            try
            {
                Vegetables vegetables = await _service.GetById(id);
                return Ok(new { Success = true, Data = vegetables });
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, new { Success = false, Message = "Internal server error" });
            }
        }
        [HttpPost("/InsertVegetable")]
        public async Task<IActionResult> Insert([FromBody] Vegetables vegetables)
        {
            if (vegetables == null)
            {
                return BadRequest(new { Success = false, Message = "Invalid vegetable data." });
            }

            try
            {
                bool result = await _service.Insert(vegetables);
                if (result)
                {
                    return CreatedAtAction(nameof(GetAll), new { id = vegetables.vegetable_id }, new { Success = true });
                }
                else
                {
                    return BadRequest(new { Success = false, Message = "Failed to insert vegetable." });
                }
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, new { Success = false, Message = "Internal server error" });
            }
        }

        [HttpPut("/Update")]
        public async Task<IActionResult> Update([FromBody] Vegetables vegetables)
        {
            if (vegetables == null)
            {
                return BadRequest(new { Success = false, Message = "Invalid vegetable data." });
            }

            try
            {
                bool result = await _service.Update(vegetables);
                if (result)
                {
                    return NoContent(); 
                }
                else
                {
                    return NotFound(new { Success = false, Message = "Vegetable not found." });
                }
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, new { Success = false, Message = "Internal server error" });
            }
        }

        [HttpDelete("/Delete")]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            if (id <= 0)
            {
                return BadRequest(new { Success = false, Message = "Invalid vegetable ID." });
            }

            try
            {
                bool result = await _service.Delete(id);
                if (result)
                {
                    return NoContent(); 
                }
                else
                {
                    return NotFound(new { Success = false, Message = "Vegetable not found." });
                }
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, new { Success = false, Message = "Internal server error" });
            }
        }
    }
}
