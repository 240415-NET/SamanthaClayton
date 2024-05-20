using TrackMyStuff.Models;
using TrackMyStuff.Data;

namespace TrackMyStuff.Controllers;


// This is my "controller"
// This controller handles all business logic related to the user class
// It will contain mostly if not only methods (at least until we 
// decide to add things like logging later on during training).
public class UserController
{

    //Here, we will add an object to do data access stuff with
    private static IUserStorageRepo _userData = new JsonUserStorage();
    // We CANNOT instantiate an object representation of an interface
    // We CAN however create an object of a class
    //that implements that interface and store it in a varable of the 
    //interface's type
    // You can instantiate an object of some type that
    //implements that interface & store it in a variable of that type



    // This function handles th ebusiness logic related to creating
    // a new user profile, using the User class
    // This function will take input from another function in the
    // presentation layer for the user name.
    // It will then create the uesr object that we will eventually
    // store and it will pass that created user object to the 
    // data access layer
    public static void CreateUser(string userName)
    {
       // Creating the user
       User newUser = new User(userName);

       // Adding a WriteLine to verify that we got here from the presentation layer
       Console.WriteLine($"User {newUser.userName} created using CreateUser()!");
       Console.WriteLine($"{newUser.userId}");

       // Eventually, we'll come here and call a data access method
       // to store the user.
        _userData.StoreUser(newUser);

    }

    // This function will eventually be used to check if a given
    // username already exists in our data store

    public static bool UserExists(string userName)
    {
        //We will need to write some method in our UserStorage
        
        if(_userData.FindUser(userName)!=null)
        {
            return true;
        }

        return false;
    }

        // This function returns user information from our data layer
    public static User ReturnUser (string userName)

    {
        User existingUser = _userData.FindUser(userName);
        return existingUser;
    }

}