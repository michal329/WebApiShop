using System.Text.Json;
using Entity;
namespace Repositories  
{
    public class UserRepositories:IUserRepositories
    {
        string filePath = "C:\\Users\\user1\\Desktop\\WebApiShop\\users.txt";

        public User addUser(User newUser)
        {
            int numberOfUsers = System.IO.File.ReadLines(filePath).Count();
            newUser.id = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(newUser);
            System.IO.File.AppendAllText(filePath, userJson + Environment.NewLine);
            return newUser;
        }

        public User loginUser(LoginUser User)
        {


            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string? currentLine;
                while ((currentLine = reader.ReadLine()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentLine);
                    if (User != null && User.userName == user.userName && User.password == user.password)
                        return user;
                }


            }
 
            return null;
        }

        public User getUserById(int id)
        {


            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.id == id)
                        return user;
                }
            }
            return null;

        }

        public void UpdateUser(int id, User updateUser)
        {
            string textToReplace = string.Empty;
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {

                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.id == id)
                        textToReplace = currentUserInFile;
                }
            }
            if (textToReplace != string.Empty)
            {
                string text = System.IO.File.ReadAllText(filePath);
                text = text.Replace(textToReplace, JsonSerializer.Serialize(updateUser));
                System.IO.File.WriteAllText(filePath, text);
            }
        }












    }
}
