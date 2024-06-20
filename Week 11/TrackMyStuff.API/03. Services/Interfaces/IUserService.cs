using TrackMyStuff.API.Models;

namespace TrackMyStuff.API.Services;

public interface IUserService
{
       public Task<User> CreateNewUserAsync(User newUserSentFromController);

          public Task<User> GetUserByUsernameAsync(string usernameToFindFromController);

public  Task<string> DeleteUserByUserNameAsync(string userNameToDeleteFromController);
public Task<string> UpdateUserNameAsync(UserNameUpdateDTO userNamesToSwapFromController);



}