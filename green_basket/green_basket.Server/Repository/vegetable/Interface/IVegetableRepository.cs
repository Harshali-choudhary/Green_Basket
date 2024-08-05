using green_basket.Server.Entities;

namespace green_basket.Server.Repository.vegetable.Interface
{
    public interface IVegetableRepository
    {
        Task<List<Vegetables>> Getall();
        Task<bool> Delete(Vegetables vegetables);
        Task<bool> Insert(Vegetables vegetable);
        Task<bool> Update(Vegetables vegetable);
    }
}
