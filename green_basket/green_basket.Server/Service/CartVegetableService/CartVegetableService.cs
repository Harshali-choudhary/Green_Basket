using green_basket.Server.Entities;
using green_basket.Server.Repository.Cart_Vegetable.Interface;

namespace green_basket.Server.Service.CartVegetableService
{
    public class CartVegetableService:ICartVegetableService
    {
        private readonly ICartVegetablesRepository _repo;
        public CartVegetableService(ICartVegetablesRepository repo)
        {
            _repo = repo;
        }
        public async Task<List<Cart_Vegetables>> GetAll()=>await _repo.GetAll();
        public async Task<bool> Insert(Cart_Vegetables vegetables)=>await _repo.Insert(vegetables);
        public async Task<bool> Update(Cart_Vegetables vegetables)=>await _repo.Update(vegetables);
        public async Task<bool> Delete(int id)=>await _repo.Delete(id);
    }
}
