using green_basket.Server.Entities;

namespace green_basket.Server.Repository.Cart.Interface
{
    public interface ICartOrderRepository
    {
        Task<List<Cart_Order>> GetAll();
        Task<bool> Insert(Cart_Order cart);
        Task<bool> Update(Cart_Order cart);
        Task<bool> Delete(int id); 

    }
}
