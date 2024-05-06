namespace RealHousewivesTrivia.LogicLayer;

using RealHousewivesTrivia.DataAccessLayer;
using RealHousewivesTrivia.Models;


public class UsersLogic
{
    public static Users CreateNewUser(string userInput)
    {
        Users newUser = new Users(userInput);
        UserStorage.StoreNewUser(newUser);
        return newUser;
    }


}