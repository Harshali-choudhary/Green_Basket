using green_basket.Server.Repository.user.Interface;

namespace green_basket.Server.Service.UserService
{
    public class userService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public userService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<User>> GetAll() => await _userRepository.Getall();
        public async Task<bool> Insert(User user) => await _userRepository.Insert(user);

        public async Task<bool> UpdateDetails(User user) => await _userRepository.UpdateDetails(user);
    }
}
