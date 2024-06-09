using System.Net.Mime;
using Microsoft.EntityFrameworkCore;
using TrackMyStuff.API.Models;

namespace TrackMyStuff.API.Data;

public class UserStorage : IUserStorage
{
    private readonly TrackMyStuffContext context;
    public UserStorage (TrackMyStuffContext _contextFromBuilder)
    {
        context = _contextFromBuilder;
    }
    public async Task<User?> CreateUserInDBAsync(User newUserSentFromUserService)
    {
        context.Users.Add(newUserSentFromUserService);
        await context.SaveChangesAsync();
        return newUserSentFromUserService;
    }

    public async Task<User?> GetUserFromDBByUserNameAsync (string userNameToFindFromUserService)
    {
        User? foundUser = await context.Users.SingleOrDefaultAsync(user => user.userName == userNameToFindFromUserService);
        return foundUser;
    }

    public async Task<bool> DoesThisUserExistInDBAsync (string userNameToFindFromUserService)
    {
        return await context.Users.AnyAsync(user => user.userName == userNameToFindFromUserService);
    }
    public async Task<string> UpdateUserInDBAsync (UserNameUpdateDTO userNamesToSwapFromUserService)
    {
        User? userToUpdate = await context.Users.SingleOrDefaultAsync(user => user.userName == userNamesToSwapFromUserService.oldUserName);
        if (userToUpdate == null)
        {
            throw new Exception("User to update not found");
        }
        else
        {
            userToUpdate.userName = userNamesToSwapFromUserService.newUserName;
        }
        await context.SaveChangesAsync();
        return userNamesToSwapFromUserService.newUserName;
    }

     public async Task<string> DeleteUserFromDBAsync(string userNameToDeleteFromUserService)
    {
        User? userToDelete = await GetUserFromDBByUserNameAsync(userNameToDeleteFromUserService);
        if (userToDelete == null)
        {
            throw new Exception("User was null");
        }
        context.Users.Remove(userToDelete);
        await context.SaveChangesAsync();
        return userNameToDeleteFromUserService;
    }

}