using green_basket.Server.Entities;
using green_basket.Server.Repository.vegetable.Interface;

namespace green_basket.Server.Service.VegetableService
{
    public class VegetableService : IVegetableService   
    {
        private readonly IVegetableRepository _repo;
        public VegetableService(IVegetableRepository repo) 
        {
            _repo = repo;
        }

        public async Task<List<Vegetables>> GetAll()=>await _repo.GetAll();
        public async Task<bool> Insert(Vegetables vegetables)=>await _repo.Insert(vegetables);  
        public async Task<bool> Update(Vegetables vegetables)=>await _repo.Update(vegetables);
        public async Task<bool> Delete(int id)=>await _repo.Delete(id);

        public async Task<Vegetables> GetById(int Id) =>await _repo.GetById(Id);
    }
}
