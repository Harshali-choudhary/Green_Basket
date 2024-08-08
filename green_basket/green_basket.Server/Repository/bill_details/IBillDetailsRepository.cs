using green_basket.Server.Entities;

namespace green_basket.Server.Repository.bill_details
{
    public interface IBillDetailsRepository
    {
        Task<List<BillDetails>> GetAll();
        Task<bool> Insert(BillDetails bill);
        Task<bool> Update(BillDetails bill);
        Task<bool> Delete(int billId);
    }
}
