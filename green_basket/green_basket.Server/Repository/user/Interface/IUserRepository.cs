using green_basket.Server.Entities;

namespace green_basket.Server.Repository.user.Interface
{
    public interface IUserRepository
    {
        public Task<List<User>> Getall();
       // public Task<bool> Insert(User user);
       // public Task<bool> Update(User user);
       // public Task<bool> Delete(User user);


    }
}
