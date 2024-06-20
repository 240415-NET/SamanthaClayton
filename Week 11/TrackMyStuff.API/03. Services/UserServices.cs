using TrackMyStuff.API.Models;
using TrackMyStuff.API.Data;
using Azure.Identity;

namespace TrackMyStuff.API.Services;

public class UserService : IUserService
{

   // The same way that our UserService is given to our UserController
   // via dependency injection, we need something to store our data
   // access object for database operations relating to the User model.
   // Again, we will create private readonly objects that we don't
   // create using "new" anywhere in this class.

   private readonly IUserStorageEFRepo _userStorage;

   public UserService(IUserStorageEFRepo efRepoFromBuilder)
   {
      _userStorage = efRepoFromBuilder;
   }

   // This method will hold the business logic we decide on for
   // creating a user.  It is called by our UserController's PostNewUser()
   // method and then it will hopefully call our UserStorageEFRepo's method
   // for sticking the new user into the database.  Even with the increasing
   // scope of our applications, we respect layer separation.
   public async Task<User> CreateNewUserAsync(User newUserSentFromController)
   {
        // Our rules for being able to create a user
        // 1. No duplicate names
        // 2. Name cannot be blank

        // Because we are not using any direct Console user interaction,
        // we use exceptions as part of our input validation. If the user doesn't
        // meet our logic's requirements, we manually throw exceptions
        // that then trigger the catch block inside of our UserController.

        // We can throw specific exceptions here that can trigger different
        // catch blocks in our UserController's method.

        // Checking is a user already exists via the username and the UserExists()
        // method.
        if(await UserExistsAsync(newUserSentFromController.userName) == true)
        {
            // If this returns a true and we enter this code block,
            // we will manually throw an exception.
            // This will trigger the catch in the UserController and send
            // our message to the user.
            throw new Exception("User already exists");
            //throw new InvalidOperationException("User already exists");
        }
       // Checking to see if the user name is blank
       if(String.IsNullOrEmpty(newUserSentFromController.userName) == true)
       {
        throw new Exception("Username cannot be blank");
        //throw new ArgumentNullException("Username cannot be blank");
       }


        // At some point, we will have to call the data access layer before
        // creating a new user and check for an existing user with that name
        await _userStorage.CreateUserInDBAsync(newUserSentFromController);

        // If this all goes smoothly and we successfully call the method
        // in the data access layer to create a new user, we will just
        // echo back the object that was sent to us by the controller.
        // Later on, we can worry about a more meaningful return.
        return newUserSentFromController;
   }

// Method to check if a user exists. During early development, we will
// return a false everytime.  Later on, we can flesh this out more.
   public async Task<bool> UserExistsAsync(string userNameToFindFromController)
   {
         return await _userStorage.DoesThisUserExistInDBAsync(userNameToFindFromController);
         
   }


// 'Task' says when we're done, you can expect the User.
//  We don't know how long it'll take.
   public async Task<User> GetUserByUsernameAsync(string usernameToFindFromController)
   {

      // Before we pass the string ot the data acces layer to see if
      // the front end passed us an empty or null string. If either of those
      // are true, we don't hit the data access layer, we just return
      // this manually thrown exception
      if(String.IsNullOrEmpty(usernameToFindFromController))
      {
         throw new Exception ("Cannot pass in a null or empty string");
      }

      // We do call the data access layer.  Because at this point, we
      // have no idea if the given string corresponds to a user object,
      // we don't know how this method call will go.  So we wrap it in a try-catch
      // so that we don't crash the entire API if someone
      // makes a typo from the front end.
      
      try
      {

         // Creating a user object that can be null in order to check if the user
         // was actually found before returning it to the controller layer

         User? foundUser = await _userStorage.GetUserFromDBByUsernameAsync(usernameToFindFromController);
         
         // If our data access layer's SingleOrDefaultAsync call doesn't find a user
         // that has the given passed in username, it will return a null.
         // Here we check for that null and if foundUser is null, we manually
         // throw an exception that is caught in the try-catch of the controller
         // and that gets sent back to the front-end.
         if (foundUser == null)
         {
            throw new Exception("User not found in DB");
         }

         return foundUser;
      }
      catch(Exception e)
      {
         throw new Exception (e.Message);
      }
   }

public async Task<string> DeleteUserByUserNameAsync(string userNameToDeleteFromController)
{
   // Let's leverage UserExistsAsync.
   // If the user exists we delete it


   try
   {
      if (await UserExistsAsync(userNameToDeleteFromController) == true)
      {
         await _userStorage.DeleteUserFromDBAsync(userNameToDeleteFromController);
         //don't need await before because this DeleteUserFromDBAsync returns void
      }
      // If not, we throw an exception to enter the controller's catch block
      else
      {
         throw new Exception("User does not exist & cannot be deleted");
      }
      return userNameToDeleteFromController;
   }
   catch (Exception e)
   {
      throw new Exception(e.Message);
   }
}

// Method in our Service Layer called by our controller to updat
// a user's username.  It will call the data access layer for a method to do

public async Task<string> UpdateUserNameAsync(UserNameUpdateDTO userNamesToSwapFromController)
{
   return await _userStorage.UpdateUserInDBAsync(userNamesToSwapFromController);
}

}