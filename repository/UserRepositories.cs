using Repositories.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Repositories
{
    public class UserRepositories : IUserRepositories
    {
        private readonly MyUsersDBContext _context;

        public UserRepositories(MyUsersDBContext context)
        {
            _context = context;
        }

        public async Task<User> addUserAsync(User newUser)
        {
            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();
            return newUser;
        }

        public async Task<User> loginUserAsync(LoginUser loginUser)
        {
            return await _context.Users.FirstOrDefaultAsync(u =>
                u.UserName == loginUser.UserName && u.Password == loginUser.Password);
        }

        public async Task<User> getUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task UpdateUserAsync(int id, User updateUser)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return;

            user.FirstName = updateUser.FirstName;
            user.LastName = updateUser.LastName;
            user.UserName = updateUser.UserName;
            user.Password = updateUser.Password;

            await _context.SaveChangesAsync();
        }
    }
}
