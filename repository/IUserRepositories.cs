using Repositories.Models;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IUserRepositories
    {
        Task<User> addUserAsync(User newUser);
        Task<User> getUserByIdAsync(int id);
        Task<User> loginUserAsync(LoginUser loginUser);
        Task UpdateUserAsync(int id, User updateUser);
    }
}
