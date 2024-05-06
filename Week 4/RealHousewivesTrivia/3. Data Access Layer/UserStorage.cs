using System.Text.Json;
using RealHousewivesTrivia.Models;

namespace RealHousewivesTrivia.DataAccessLayer;

public class UserStorage
{
public readonly static string _filePath = "./3. Data Access Layer/UserData.json";


public static void StoreNewUser(Users newuser)
{
    if(File.Exists(_filePath))
    {
        string allExistingUsersInStorage_jsonformat = File.ReadAllText(_filePath);
        List<Users> allExistingUsersInStorage = JsonSerializer.Deserialize<List<Users>>(allExistingUsersInStorage_jsonformat);
        allExistingUsersInStorage.Add(newuser);
        string allExistingUsersInStorage_RevisedList_jsonformat = JsonSerializer.Serialize(allExistingUsersInStorage);
        File.WriteAllText(_filePath, allExistingUsersInStorage_RevisedList_jsonformat);
    }
    else if (!File.Exists(_filePath))
    {
        List<Users> startingNewList = new List<Users>();
        startingNewList.Add(newuser);
        string startingNewList_jsonformat = JsonSerializer.Serialize(startingNewList);
        File.WriteAllText(_filePath, startingNewList_jsonformat);


    }


    }
}

