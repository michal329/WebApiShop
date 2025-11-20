using Entity;

namespace Services
{
    public interface IUserServices
    {
        User addUser(User user);
        User getUserById(int id);
        User loginUser(LoginUser loginUser);
        bool updateUser(int id, User user);
    }
}