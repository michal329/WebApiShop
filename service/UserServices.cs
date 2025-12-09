using Repositories.Models;
using Repositories;
using Services;
using System.Threading.Tasks;

namespace service
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepositories _userRepository;
        private readonly IPasswordServices _passwordService;

        public UserServices(IUserRepositories userRepository, IPasswordServices passwordService)
        {
            _userRepository = userRepository;
            _passwordService = passwordService;
        }

        public async Task<User> AddUserAsync(User newUser)
        {
            int passScore = _passwordService.GetPasswordScore(newUser.Password);
            if (passScore < 2) return null;

            return await _userRepository.AddUserAsync(newUser);
        }

        public async Task<User> LoginUserAsync(LoginUser user)
        {
            return await _userRepository.LoginUserAsync(user);
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }

        public async Task<bool> UpdateUserAsync(int id, User user)
        {
            int passScore = _passwordService.GetPasswordScore(user.Password);
            if (passScore < 2) return false;

            await _userRepository.UpdateUserAsync(id, user);
            return true;
        }
    }
}
