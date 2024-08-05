using green_basket.Server.Entities;

namespace green_basket.Server.Repository.user.Interface
{
    public interface IUserRepository
    {
        Task<List<User>> Getall();
        Task<bool> Insert(User user);
        Task<bool> Update(User user);
        Task<bool> Delete(User user);


    }
}
