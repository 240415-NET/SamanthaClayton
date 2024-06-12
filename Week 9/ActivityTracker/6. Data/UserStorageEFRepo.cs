using ActivityTracker.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace ActivityTracker.Data;
public class UserStorageEFRepo : IUserStorageEFRepo
{
    private readonly DataContext _dataContext;
    public UserStorageEFRepo(DataContext dataContextFromBuilder)
    {
        _dataContext = dataContextFromBuilder;
    }
    public async Task<User> CreateNewUserInDBAsync(User newUserSentFromUserService)
    {
        _dataContext.users.Add(newUserSentFromUserService);
        await _dataContext.SaveChangesAsync();
        return newUserSentFromUserService;
    }

    public async Task<bool> DoesThisUserExistInDBAsync(string userNameToFindFromUserService)
    {
            return await _dataContext.users.AnyAsync(user => user.userName == userNameToFindFromUserService);
    }

    public async Task<string> DeleteUserinDBAsync(string userName)
    {
        User? userToDelete = await _dataContext.users.FirstOrDefaultAsync(
            user => user.userName == userName);

        if (userToDelete != null)
        {
            _dataContext.users.Remove(userToDelete);
            await _dataContext.SaveChangesAsync();
            return $"{userToDelete.userName} was removed";
        }
        else
        {
            throw new Exception("User not found");

        }

    }

    public async Task<User> GetUserByUserNameFromDBAsync(string userNameToFindFromUserService)
    {
        User foundUser = await _dataContext.users.SingleOrDefaultAsync(user => user.userName == userNameToFindFromUserService);
        return foundUser;
    }

    public async Task<string> UpdateUserinDBAsync(UpdateUsernameDTO usernamesToSwapFromUserService)
    {
         User? userToUpdate = await _dataContext.users
            .SingleOrDefaultAsync(user => user.userName == usernamesToSwapFromUserService.oldUserName);

            if(userToUpdate == null)
        {
            throw new Exception("User not found!");
        }
        else
        {
            userToUpdate.userName = usernamesToSwapFromUserService.newUserName;
        }

        await _dataContext.SaveChangesAsync();

        return usernamesToSwapFromUserService.newUserName;
    }
}