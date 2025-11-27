using System.Text.Json;
using Entity;
namespace Repositories  
{
    public class UserRepositories : IUserRepositories
    {
        string filePath = Path.Combine(Directory.GetCurrentDirectory(), "users.txt");

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
                    if (user != null && User != null && User.userName == user.userName && User.password == user.password)
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
            updateUser.id = id;
            string textToReplace = string.Empty;
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {

                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user != null && user.id == id)
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
