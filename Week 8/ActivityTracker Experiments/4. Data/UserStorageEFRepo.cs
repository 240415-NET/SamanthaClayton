using ActivityTracker.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace ActivityTracker.Data;
public class UserStorageEFRepo : IUserStorageEFRepo
{
    private readonly DataContext dataContext;
    public UserStorageEFRepo(DataContext dataContextFromBuilder)
    {
        dataContext = dataContextFromBuilder;
    }
    public async Task<User> CreateNewUserInDBAsync(User newUserSentFromUserService)
    {
        dataContext.Users.Add(newUserSentFromUserService);
        await dataContext.SaveChangesAsync();
        return newUserSentFromUserService;
    }

    public async Task<User> GetUserByUserNameFromDBAsync(string userNameToFindFromUserService)
    {
        User? foundUser = await dataContext.Users.SingleOrDefaultAsync(user => user.userName == userNameToFindFromUserService);
        
        if (foundUser == null)
        {
            throw new Exception ("User not found in database.");
        }
        return foundUser;
    }

    public async Task<string> DeleteUserByUserNameFromDBAsync (string userNameToDeleteFromUserService)
    {
        User userToDelete = await GetUserByUserNameFromDBAsync(userNameToDeleteFromUserService);
        dataContext.Users.Remove(userToDelete);
        await dataContext.SaveChangesAsync();
        return userNameToDeleteFromUserService;

    }
    
    public async Task<string> UpdateUserInDBAsync(string oldUserName, string newUserName)
    {
        User? userToUpdate = await GetUserByUserNameFromDBAsync(oldUserName);
        userToUpdate.userName = newUserName;
        await dataContext.SaveChangesAsync();
        return newUserName;
    }


}