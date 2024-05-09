using System.Text.Json;
using Project1.Models;

namespace Project1.DataAccessLayer;

public class JsonUsersStorage : IUsersStorageRepo
{
    public readonly static string _filePath = "./3. Data Access Layer/UserData.json";

    public void StoreNewUser(Users newUser)
    {
        if(File.Exists(_filePath))
        {
            string usersInStorageJSON = File.ReadAllText(_filePath);
            List<Users> usersInStorageList = JsonSerializer.Deserialize<List<Users>>(usersInStorageJSON);
            usersInStorageList.Add(newUser);
            string revisedUsersInStorageJSON = JsonSerializer.Serialize<List<Users>>(usersInStorageList);
            File.WriteAllText(_filePath, revisedUsersInStorageJSON);
        }
        else if (!File.Exists(_filePath))
        {
            List<Users> freshUsersInStorageList = new List<Users>();
            freshUsersInStorageList.Add(newUser);
            string freshUsersInStorageJSON = JsonSerializer.Serialize<List<Users>>(freshUsersInStorageList);
            File.WriteAllText(_filePath, freshUsersInStorageJSON);
        }
    }


    public Users SearchUsersStorage(string userNameToFind)
    {
        Users existingUser = new Users();

        try
        {
            string usersInStorageJSON = File.ReadAllText(_filePath);
            List<Users> usersInStorageList = JsonSerializer.Deserialize<List<Users>>(usersInStorageJSON);
            existingUser = usersInStorageList.FirstOrDefault(findmyuser => findmyuser.userName == userNameToFind);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }

        return existingUser;

    }




}