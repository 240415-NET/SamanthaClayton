using TrackMyStuff.API.Models;

namespace TrackMyStuff.API.Data;

public interface IUserStorage
{
    public Task<User?> CreateUserInDBAsync(User newUserSentFromUserService);
    public Task<User?> GetUserFromDBByUserNameAsync (string userNameToFindFromUserService);
    public Task<bool> DoesThisUserExistInDBAsync (string userNameToFindFromUserService);
    public Task<string> UpdateUserInDBAsync (UserNameUpdateDTO userNamesToSwapFromUserService);
    public Task<string> DeleteUserFromDBAsync(string userNameToDeleteFromUserService);

}