using TrackMyStuff.API.Models;

namespace TrackMyStuff.API.Services;

public interface IUserService
{
    public Task<User> CreateNewUserAsync(User newUserSentFromController);
    public Task<User> GetUserByUserNameAsync(string userNameToFindFromController);
    public Task<bool> UserExistsAsync(string userNameToFindFromController);
    public Task<string> UpdateUserNameAsync(UserNameUpdateDTO userNamesToSwapFromController);
    public Task<string> DeleteUserByUserNameAsync(string userNameToDeleteFromController);
}