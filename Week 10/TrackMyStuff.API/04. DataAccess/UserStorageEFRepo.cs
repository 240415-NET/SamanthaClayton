using TrackMyStuff.API.Models;
using TrackMyStuff.API.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Http.HttpResults;

namespace TrackMyStuff.API.Data;

public class UserStorageEFRepo : IUserStorageEFRepo
{

    // This holds our context object that will do 
    // the database data transfer stuff for us
    // using pre-built EF Core methods
    private readonly TrackMyStuffContext _context;
    public UserStorageEFRepo(TrackMyStuffContext contextFromBuilder)
    {
        _context = contextFromBuilder; //we will use this to call the EF methods
    }
    public async Task<User?> CreateUserInDBAsync(User newUserSentFromUserService)
    // the ? allows us to return a blank User if we want to
    {
        // Here we will actually create the user in our DB
       
       //First we use the context object
       // Then we reference the table we want to add the object to
       // And then use .Add() to add it to stage it for saving
        _context.Users.Add(newUserSentFromUserService);

        // We can add as many objects we need to before we save, but be
        // mindful that nothing actually reflects in the DB until we call
        // SaveChangesAsync().
        // This line, whihc we await, is what sticks our user into our DB.
        await _context.SaveChangesAsync();

        return newUserSentFromUserService;
        

    }


// We don't know if we'll find a user, so make it nullable
    public async Task<User?> GetUserFromDBByUsernameAsync(string userNameToFindFromUserService)
    {
        // We are going to attempt to find a user based on the string
        // We originally tried to use FindAsync(), but this takes
        // the primary key as its argument
        // User? foundUser = await _context.Users.FindAsync(userNameToFindFromUserService);
        //                          our context object.Users << the Users table.FindAsync
        // In this method call, we ask using LINQ for a single uesr
        // based on it's username matching the usernameToFindFromUesrSErvice that
        // we passed in.
        // SingleOrDefaultAsync will look for 2 entires to see if there are multiple
        // It's validating that
        // It will also not throw an error if the user is null
        // You could do FirstOrDefaultAsync too but this metohd won't inform
        // you that there are multiple uesrs with the same name.
        User? foundUser = await _context.Users.SingleOrDefaultAsync(user => user.userName == userNameToFindFromUserService);
       
       
        // Returning either hte uesr we found or null to the serivce layer
        //Checking for a null in our application will be part of our business logic
        return foundUser;

    }

    // New method using the .Any() LINQ method ot check if a user exists
    // in our DB.  This method will return a boolean, it does not 
    // care about returning any sort of user object or information about a user 
    // if they do exist.  Just whether or not they exist at all.
    public async Task<bool> DoesThisUserExistInDBAsync(string userNameToFindFromUserService)
    {
        // We are just going to call .Any() method, which returns a boolean
        // true/false.  If the user exists in the DB, it resolves to true.
        // Otherwise, it resolves to false.
        return await _context.Users.AnyAsync(user => user.userName == userNameToFindFromUserService);
    }

    public async Task<string> DeleteUserFromDBAsync(string userNameToDeleteFromUserService)
    {
        // In this one line, we do a few things
        // We know coming into this method that we already checked if the user exists
        // By definition, we will be deleting someone here.
        // We call the .Remove() EF Core method to remove the object
        // we passed into it from the database. Instead of going through
        // the steps to find the user again, we simply call the
        // GetUserFromDBByUserNameAsync() method that we already created
        // and re-use it to provide our user to be delete
        User? userToDelete = await GetUserFromDBByUsernameAsync(userNameToDeleteFromUserService);
        if (userToDelete == null)
        {
            throw new Exception("Thrown from the db layer, user was null");
        }
        _context.Users.Remove(userToDelete);

        // Just like a POST, we then nede to call Savechanges or SaveChangesAsync
        // using our context object to persist this deletion to the DB.
        await _context.SaveChangesAsync();
        return userNameToDeleteFromUserService;
    }

// This method will update the uesrname for a given user object in our DB
// It's called from the Service Layer and takes in a UserNameUpdateDTO
public async Task<string> UpdateUserInDBAsync(UserNameUpdateDTO userNamesToSwapFromUserService)
{
    // Create a user object (nullable) to hold our database return
    // We will query the DB for a user who corresponds to the UserNameUpdateDTO's oldUserName string
    User? userToUpdate = await _context.Users.SingleOrDefaultAsync(user => user.userName == userNamesToSwapFromUserService.oldUserName);

    //The above is the ame as
    //User? userToUpdate = new();
    //userToUpdate = await _context.... 
    
    // When we create these methods, the runtime is creating these objects on the file. 
    //ASP.NET is handling the disposal of these context objects.
    // If we callGetUserFromDBUsernameAsync(), we might mix up our contexts.
    // But he's not sure and he wants us to learn lambdas.
    //User? userToUpdate = await GetUserFromDBByUsernameAsync(userNamesToSwapFromUserService.oldUserName);
    
    if (userToUpdate == null)
    {
        throw new Exception("User to update not found");
    }
    else
    {
        userToUpdate.userName = userNamesToSwapFromUserService.newUserName;
    }
    await _context.SaveChangesAsync();
    return userNamesToSwapFromUserService.newUserName;
}
}