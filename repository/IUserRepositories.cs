using Entity;

namespace Repositories
{
    public interface IUserRepositories
    {
        User addUser(User newUser);
        User getUserById(int id);
        User loginUser(LoginUser loginUser);
        void UpdateUser(int id, User updateUser);

    }
}
