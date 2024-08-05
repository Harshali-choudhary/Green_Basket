using green_basket.Server.Entities;

namespace green_basket.Server.Repository.user.Interface
{
    public interface IUserRepository
    {
<<<<<<< HEAD
        public Task<List<User>> Getall();
       // public Task<bool> Insert(User user);
       // public Task<bool> Update(User user);
       // public Task<bool> Delete(User user);
=======
        Task<List<User>> Getall();
        Task<bool> Insert(User user);
        Task<bool> UpdateDetails(User user);
       // Task<bool> Delete(User user);
>>>>>>> 85c082e2df78a89fdaba8acd585abe8fca6102fa


    }
}
