using green_basket.Server.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using green_basket.Server.Service.VegetableService;

namespace green_basket.Server.Controllers
{
    [ApiController]
    [Route("/api/vegetable")]
    public class VegetableController : ControllerBase
    {
        private readonly IVegetableService _service;

        public VegetableController(IVegetableService service)
        {
            _service = service;
        }
        
        [HttpGet]
        public async Task<List<Vegetables>> GetAll()
        {
            List<Vegetables> vegetables= await _service.GetAll();
            return vegetables;
        }
        [HttpPost]
        public async Task<bool> Insert([FromBody] Vegetables vegetables)
        {
            bool result= await _service.Insert(vegetables);
            return result;
        }
        [HttpPut]
        public async Task<bool> Update(Vegetables vegetables)
        {
            bool result= await _service.Update(vegetables);
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
