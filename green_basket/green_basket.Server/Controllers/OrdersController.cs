using green_basket.Server.Entities;
using green_basket.Server.Service.orderService;
using Microsoft.AspNetCore.Mvc;

namespace green_basket.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<List<Orders>> GetAllOrders()
        {
            List<Orders> orderList = await  _orderService.GetAllOrders();
            return orderList;
        }

        [HttpPost]
        public async Task<bool> InsertOrder([FromBody]Orders order)
        {
            bool status = await _orderService.InsertOrder(order);
            return status;
        }

        [HttpPut]
        public async Task<bool> UpdateOrder([FromBody]Orders o)
        {
            bool status = await _orderService.UpdateOrder(o);
            return status;
        }

        [HttpDelete]
        public  async Task<bool> DeleteOrder([FromBody]int order_id)
        {
            bool status = await _orderService.DeleteOrder(order_id);
            return status;
        }
    }
}
