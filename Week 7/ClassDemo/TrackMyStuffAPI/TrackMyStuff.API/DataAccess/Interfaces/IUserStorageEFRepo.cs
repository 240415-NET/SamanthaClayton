using TrackMyStuff.API.Models;

namespace TrackMyStuff.API.Data;

public interface IUserStorageEFRepo
{
    public Task<User?> CreateUserInDBAsync(User newUserSentFromUserService);
// the ? allows us to return a blank User if we want to

}