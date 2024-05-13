using Project1.Models;
using Project1.DataAccessLayer;

namespace Project1.LogicLayer;

public class UsersLogic
{

    private static IUsersStorageRepo _userData = new JsonUsersStorage();

    public static Users CreateNewUser(string userInput)
    {
        Users newUser = new Users(userInput);
        _userData.StoreNewUser(newUser);
        return newUser;
    }

    public static bool CheckIfUserExists(string userName)
    {
        if(_userData.RetrieveStoredUser(userName) != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static Users GetExistingUser(string userName)
    {
        Users existingUser = _userData.RetrieveStoredUser(userName);
        return existingUser;
    }


}