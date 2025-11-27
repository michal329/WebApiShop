using Entity;
using Repositories;
using Services;
namespace service
{

    public class UserServices : IUserServices
    {
        private readonly IUserRepositories userRepository;
        private readonly IPasswordServices passwordService;

        public UserServices(IUserRepositories userRepositories, IPasswordServices passwordServices)
        {
            userRepository = userRepositories;
            passwordService = passwordServices;
        }
        public User addUser(User newUser) {
            return userRepository.addUser(newUser);

        }

        public User loginUser(LoginUser User)
        {

           return userRepository.loginUser(User);

        }

        public User getUserById(int id)
        {

            return userRepository.getUserById(id);

        }
        public bool updateUser(int id, User user)
        {
            userRepository.UpdateUser(id, user);
            return true;

        }


    }
}
