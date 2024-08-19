using green_basket.Server.Entities;
using green_basket.Server.Service.BillService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace green_basket.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BillDetailsController : ControllerBase
    {
        private readonly IBillDetailsService _billDetailsService;

        public BillDetailsController(IBillDetailsService billDetailsService)
        {
            _billDetailsService = billDetailsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var list = await _billDetailsService.GetAll();
                return Ok(new { Success = true, Data = list });
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, new { Success = false, Message = "Internal server error" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] BillDetails bill)
        {
            if (bill == null)
            {
                return BadRequest(new { Success = false, Message = "Invalid bill details." });
            }

            try
            {
                bool status = await _billDetailsService.Insert(bill);
                if (status)
                {
                    return CreatedAtAction(nameof(GetAll), new { id = bill.bill_id }, new { Success = true, Data = bill });
                }
                else
                {
                    return BadRequest(new { Success = false, Message = "Failed to insert bill details." });
                }
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, new { Success = false, Message = "Internal server error" });
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] BillDetails bill)
        {
            if (bill == null)
            {
                return BadRequest(new { Success = false, Message = "Invalid bill details." });
            }

            try
            {
                bool status = await _billDetailsService.Update(bill);
                if (status)
                {
                    return NoContent(); 
                }
                else
                {
                    return NotFound(new { Success = false, Message = "Bill details not found." });
                }
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, new { Success = false, Message = "Internal server error" });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                bool status = await _billDetailsService.Delete(id);
                if (status)
                {
                    return NoContent(); 
                }
                else
                {
                    return NotFound(new { Success = false, Message = "Bill details not found." });
                }
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, new { Success = false, Message = "Internal server error" });
            }
        }
    }
}
