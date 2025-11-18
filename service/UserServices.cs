using Entity;
using Repositories;
using Services;
namespace service
{

    public class UserServices
    {
        private UserRepositories userRepository = new UserRepositories();
        private PasswordServices passwordService = new PasswordServices();
        public User addUser(User newUser) {

            int passScore = passwordService.GetPasswordScore(newUser.password);
            if (passScore < 2)
                return null;

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
        public bool updateUser(int id,User user)
        {

            int passScore = passwordService.GetPasswordScore(user.password);
            if (passScore < 2)
                return false;
            userRepository.UpdateUser(id, user);
            return true;

        }


    }
}
