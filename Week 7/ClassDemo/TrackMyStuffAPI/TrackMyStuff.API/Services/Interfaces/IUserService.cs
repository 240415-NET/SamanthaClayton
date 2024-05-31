using TrackMyStuff.API.Models;

namespace TrackMyStuff.API.Services;

public interface IUserService
{
       public Task<User> CreateNewUserAysnc(User newUserSentFromController);



}