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

    
}