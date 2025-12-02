using Repositories.Models;
using System.Threading.Tasks;

namespace Services
{
    public interface IUserServices
    {
        Task<User> addUserAsync(User user);
        Task<User> getUserByIdAsync(int id);
        Task<User> loginUserAsync(LoginUser loginUser);
        Task<bool> updateUserAsync(int id, User user);
    }
}
