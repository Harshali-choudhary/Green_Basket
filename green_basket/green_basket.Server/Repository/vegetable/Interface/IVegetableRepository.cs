using green_basket.Server.Entities;

namespace green_basket.Server.Repository.vegetable.Interface
{
    public interface IVegetableRepository
    {
        Task<List<Vegetables>> GetAll();
        Task<bool> Delete(int id);
        Task<bool> Insert(Vegetables vegetable);
        Task<bool> Update(Vegetables vegetable);
        Task<Vegetables> GetById(int id);
    }
}
