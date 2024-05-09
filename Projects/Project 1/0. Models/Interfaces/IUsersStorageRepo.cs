namespace Project1.Models;

public interface IUsersStorageRepo
{
    public void StoreNewUser(Users newUser);

    public Users SearchUsersStorage(string userNameToFind);


}