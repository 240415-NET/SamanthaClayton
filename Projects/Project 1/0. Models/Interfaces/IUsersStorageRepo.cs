namespace Project1.Models;

public interface IUsersStorageRepo
{
    public void StoreNewUser(Users newUser);

    public Users RetrieveStoredUser(string userNameToFind);


}