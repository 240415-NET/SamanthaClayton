using TrackMyStuff.API.Data;
using TrackMyStuff.API.Models;

namespace TrackMyStuff.API.Services;

public class UserService : IUserService
{

    private readonly IUserStorage userStorage;
    public UserService(IUserStorage _userStorage)
    {
        userStorage = _userStorage;
    }

     public async Task<User> CreateNewUserAsync(User newUserSentFromController)
    {
        if(await UserExistsAsync(newUserSentFromController.userName))
        {
            throw new Exception("User already exists");
        }
        if(String.IsNullOrEmpty(newUserSentFromController.userName))
        {
            throw new Exception("Username cannot be blank");
        }
        await userStorage.CreateUserInDBAsync(newUserSentFromController);
        return newUserSentFromController;

    }

    
    public async Task<User> GetUserByUserNameAsync(string userNameToFindFromController)
    {
        if(String.IsNullOrEmpty(userNameToFindFromController))
        {
            throw new Exception("Cannot pass in a null or empty string ");
        }
        try
        {
            User? foundUser = await userStorage.GetUserFromDBByUserNameAsync(userNameToFindFromController);
            if (foundUser == null)
            {
                throw new Exception("User not found in database");
            }
            return foundUser;
        }
        catch (Exception e)
        {
            throw new Exception (e.Message);
        }
    }

    public async Task<bool> UserExistsAsync(string userNameToFindFromController)
    {
        return await userStorage.DoesThisUserExistInDBAsync(userNameToFindFromController);
    }

    public async Task<string> UpdateUserNameAsync(UserNameUpdateDTO userNamesToSwapFromController)
    {
        return await userStorage.UpdateUserInDBAsync(userNamesToSwapFromController);
    }
    
    public async Task<string> DeleteUserByUserNameAsync(string userNameToDeleteFromController)
    {
        try
        {
            if(await UserExistsAsync(userNameToDeleteFromController))
            {
                await userStorage.DeleteUserFromDBAsync(userNameToDeleteFromController);
            }
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

}