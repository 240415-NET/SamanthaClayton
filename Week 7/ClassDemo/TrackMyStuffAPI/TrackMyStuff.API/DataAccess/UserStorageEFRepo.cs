using TrackMyStuff.API.Models;
using TrackMyStuff.API.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

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

    
}