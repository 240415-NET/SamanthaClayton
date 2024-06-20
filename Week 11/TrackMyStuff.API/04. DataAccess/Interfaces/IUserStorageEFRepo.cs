using TrackMyStuff.API.Models;

namespace TrackMyStuff.API.Data;

public interface IUserStorageEFRepo
{
    public Task<User?> CreateUserInDBAsync(User newUserSentFromUserService);
// the ? allows us to return a blank User if we want to
    public Task<User?> GetUserFromDBByUsernameAsync(string userNameToFindFromUserService);

    public Task<bool> DoesThisUserExistInDBAsync(string userNameToFindFromUserService);
    public Task<string> DeleteUserFromDBAsync(string userNameToDeleteFromUserService);
public Task<string> UpdateUserInDBAsync(UserNameUpdateDTO userNamesToSwap);

}