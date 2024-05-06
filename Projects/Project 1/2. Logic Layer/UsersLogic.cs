using Project1.Models;
using Project1.DataAccessLayer;
using System.Formats.Asn1;

namespace Project1.LogicLayer;

public class UsersLogic
{

    public static Users CreateNewUser(string userInput)
    {
        Users newUser = new Users(userInput);
        UsersStorage.StoreNewUser(newUser);
        return newUser;
    }

    public static bool CheckIfUserExists(string userName)
    {
        if(UsersStorage.SearchUsersStorage(userName) != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static Users FindExistingUser(string userName)
    {
        Users existingUser = UsersStorage.SearchUsersStorage(userName);
        return existingUser;
    }


}