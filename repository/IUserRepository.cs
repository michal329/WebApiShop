using Repositories.Models;

namespace Repositories
{
    public interface IUserRepository
    {
        Task<User> AddUser(User newUser);
        Task<User> GetUserById(int id);
        Task<IEnumerable<User>> GetUsers();
        Task<User> Login(LoginUser loginUser);
        Task UpdateUser(int id, User updateUser);
        Task<bool> UserWithSameEmail(string email, int id);
    }
}