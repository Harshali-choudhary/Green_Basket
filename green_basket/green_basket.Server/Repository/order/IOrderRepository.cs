using green_basket.Server.Entities;

namespace green_basket.Server.Repository.order
{
    public interface IOrderRepository
    {
        Task<List<Orders>> GetAllOrders();
        Task<bool> InsertOrder(Orders orders);
        Task<bool> UpdateOrder(Orders orders);
        Task<bool> DeleteOrder(int order_id);
    }
}
