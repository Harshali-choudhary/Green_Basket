﻿using green_basket.Server.Entities;
using green_basket.Server.Repository.user.Interface;

namespace green_basket.Server.Service.userService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<User>> Getall() => await _userRepository.Getall();
        public async Task<bool> Insert(User user) => await _userRepository.Insert(user);

        public async Task<bool> UpdateDetails(User user) => await _userRepository.UpdateDetails(user);

        public async Task<bool> Delete(string email) => await _userRepository.Delete(email);
        public async Task<User> Login(string email,string password) => await _userRepository.Login(email, password);
        public async Task<User> GetByEmail(string email) => await _userRepository.GetByEmail(email);
    }
}
