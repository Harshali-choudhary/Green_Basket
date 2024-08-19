using green_basket.Server.Entities;

namespace green_basket.Server.Repository.Cart_Vegetable.Interface
{
    public interface ICartVegetablesRepository
    {
        Task<List<Cart_Vegetables>> GetAll();
        Task<bool> Insert(Cart_Vegetables vegetables);
        Task<bool> Update(Cart_Vegetables vegetables);
        Task<bool> Delete(int id);
        Task<Cart_Vegetables> GetById(int id);
    }
}
