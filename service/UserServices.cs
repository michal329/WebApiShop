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

        public async Task<User> addUserAsync(User newUser)
        {
            int passScore = _passwordService.GetPasswordScore(newUser.Password);
            if (passScore < 2) return null;

            return await _userRepository.addUserAsync(newUser);
        }

        public async Task<User> loginUserAsync(LoginUser user)
        {
            return await _userRepository.loginUserAsync(user);
        }

        public async Task<User> getUserByIdAsync(int id)
        {
            return await _userRepository.getUserByIdAsync(id);
        }

        public async Task<bool> updateUserAsync(int id, User user)
        {
            int passScore = _passwordService.GetPasswordScore(user.Password);
            if (passScore < 2) return false;

            await _userRepository.UpdateUserAsync(id, user);
            return true;
        }
    }
}
