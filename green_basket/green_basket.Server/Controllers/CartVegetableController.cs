using green_basket.Server.Entities;
using green_basket.Server.Service.CartVegetableService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<List<Cart_Vegetables>> GetAll()
        {
            List<Cart_Vegetables> vegetables = await _service.GetAll();
            return vegetables;
        }
        [HttpPost]
        public async Task<bool> Insert([FromBody] Cart_Vegetables vegetables)
        {
            bool result = await _service.Insert(vegetables);
            return result;
        }
        [HttpPut]
        public async Task<bool> Update(Cart_Vegetables vegetables)
        {
            bool result = await _service.Update(vegetables);
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
