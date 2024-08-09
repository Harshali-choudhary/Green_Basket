using green_basket.Server.Entities;
using green_basket.Server.Service.Cart_orderService;
using Microsoft.AspNetCore.Mvc;

namespace green_basket.Server.Controllers
{
    [ApiController]
    [Route("/api/cart_order")]
    public class CartOrderController :ControllerBase
    {
        private readonly ICartOrderService _service;

        public CartOrderController(ICartOrderService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<List<Cart_Order>> GetAll()
        {
            List<Cart_Order> cart_order = await _service.GetAll();
            return cart_order;
        }
        [HttpPost]
        public async Task<bool> Insert([FromBody]Cart_Order cart_Order)
        {
            bool result = await _service.Insert(cart_Order);
            return result;
        }
        [HttpPut]
        public async Task<bool> Update([FromBody]Cart_Order cart_Order)
        {
            bool result = await _service.Update(cart_Order);
            return result;
        }
        [HttpDelete]
        public async Task<bool> Delete(int id)
        {
            bool result = await _service.Delete(id);  
            return result;
        }

    }
}
