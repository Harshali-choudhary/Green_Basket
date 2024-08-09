using green_basket.Server.Entities;
using green_basket.Server.Repository.Cart.Interface;

namespace green_basket.Server.Service.Cart_orderService
{
    public class CartOrderService : ICartOrderService
    {
        private readonly ICartOrderRepository _repo;

        public CartOrderService(ICartOrderRepository repo)
        {
            _repo = repo;
        }
        public async Task<List<Cart_Order>> GetAll()=>await _repo.GetAll(); 
        public async Task<bool> Insert(Cart_Order cart_Order)=>await _repo.Insert(cart_Order);
        public async Task<bool> Update(Cart_Order cart_Order)=>await _repo.Update(cart_Order);
        public async Task<bool> Delete(int id)=>await _repo.Delete(id);
    }
}
