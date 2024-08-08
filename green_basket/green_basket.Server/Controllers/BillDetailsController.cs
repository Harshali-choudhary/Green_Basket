using Google.Protobuf.Collections;
using green_basket.Server.Entities;
using green_basket.Server.Service.BillService;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace green_basket.Server.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class BillDetailsController : ControllerBase
    {
        private readonly IBillDetailsService _billDetailsService;

        public BillDetailsController(IBillDetailsService billDetailsService)
        {
            _billDetailsService = billDetailsService;
        }

        [HttpGet]
        public async Task<List<BillDetails>> GetAll()
        {
            List<BillDetails> list = await _billDetailsService.GetAll();
            return list;
        }
        [HttpPost]
        public async Task<bool> Insert([FromBody]BillDetails bill)
        {
            bool status = await _billDetailsService.Insert(bill);
            return status;
        }

        [HttpPut]
        public async Task<bool> Update(BillDetails bill)
        {
            bool status = await _billDetailsService.Update(bill);
            return status;
        }

        [HttpDelete]
        public async Task<bool> Delete(int id)
        {
            bool status = await _billDetailsService.Delete(id);
            return status;
        }
    }
}
