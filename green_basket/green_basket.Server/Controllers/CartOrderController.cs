using green_basket.Server.Entities;
using green_basket.Server.Service.Cart_orderService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace green_basket.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartOrderController : ControllerBase
    {
        private readonly ICartOrderService _service;

        public CartOrderController(ICartOrderService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var cartOrders = await _service.GetAll();
                return Ok(new { Success = true, Data = cartOrders });
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, new { Success = false, Message = "Internal server error" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] Cart_Order cart_Order)
        {
            if (cart_Order == null)
            {
                return BadRequest(new { Success = false, Message = "Invalid cart order data." });
            }

            try
            {
                bool result = await _service.Insert(cart_Order);
                if (result)
                {
                    return CreatedAtAction(nameof(GetAll), new { id = cart_Order.Ocart_Id }, new { Success = true, Data = cart_Order });
                }
                else
                {
                    return BadRequest(new { Success = false, Message = "Failed to insert cart order." });
                }
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, new { Success = false, Message = "Internal server error" });
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Cart_Order cart_Order)
        {
            if (cart_Order == null)
            {
                return BadRequest(new { Success = false, Message = "Invalid cart order data." });
            }

            try
            {
                bool result = await _service.Update(cart_Order);
                if (result)
                {
                    return NoContent(); // 204 No Content for successful update
                }
                else
                {
                    return NotFound(new { Success = false, Message = "Cart order not found." });
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
                    return NoContent(); 
                }
                else
                {
                    return NotFound(new { Success = false, Message = "Cart order not found." });
                }
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, new { Success = false, Message = "Internal server error" });
            }
        }
    }
}
