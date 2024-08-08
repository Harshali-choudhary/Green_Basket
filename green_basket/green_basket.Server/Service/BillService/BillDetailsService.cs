using green_basket.Server.Entities;
using green_basket.Server.Repository.bill_details;

namespace green_basket.Server.Service.BillService
{
    public class BillDetailsService : IBillDetailsService
    {
        private readonly IBillDetailsRepository billDetailsRepository;

        public BillDetailsService(IBillDetailsRepository _billDetailsRepository)
        {
            billDetailsRepository = _billDetailsRepository;
        }

        public async Task<List<BillDetails>> GetAll() => await  billDetailsRepository.GetAll();
        public async Task<bool> Insert(BillDetails billDetails) => await billDetailsRepository.Insert(billDetails);

        public async Task<bool> Update(BillDetails billDetails) => await billDetailsRepository.Update(billDetails);
        public async Task<bool> Delete(int id) => await billDetailsRepository.Delete(id);
    }
}
