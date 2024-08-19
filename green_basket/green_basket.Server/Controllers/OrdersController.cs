using green_basket.Server.Entities;
using green_basket.Server.Service.orderService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace green_basket.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            try
            {
                var orderList = await _orderService.GetAllOrders();
                return Ok(new { Success = true, Data = orderList });
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, new { Success = false, Message = "Internal server error" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertOrder([FromBody] Orders order)
        {
            if (order == null)
            {
                return BadRequest(new { Success = false, Message = "Invalid order data." });
            }

            try
            {
                bool status = await _orderService.InsertOrder(order);
                if (status)
                {
                    return CreatedAtAction(nameof(GetAllOrders), new { id = order.order_id }, new { Success = true, Data = order });
                }
                else
                {
                    return BadRequest(new { Success = false, Message = "Failed to insert order." });
                }
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, new { Success = false, Message = "Internal server error" });
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrder([FromBody] Orders order)
        {
            if (order == null)
            {
                return BadRequest(new { Success = false, Message = "Invalid order data." });
            }

            try
            {
                bool status = await _orderService.UpdateOrder(order);
                if (status)
                {
                    return NoContent();
                }
                else
                {
                    return NotFound(new { Success = false, Message = "Order not found." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Success = false, Message = "Internal server error" });
            }
        }

        [HttpDelete("{order_id}")]
        public async Task<IActionResult> DeleteOrder([FromRoute] int order_id)
        {
            try
            {
                bool status = await _orderService.DeleteOrder(order_id);
                if (status)
                {
                    return NoContent(); 
                }
                else
                {
                    return NotFound(new { Success = false, Message = "Order not found." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Success = false, Message = "Internal server error" });
            }
        }
    }
}
