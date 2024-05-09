namespace Project1.Models;

public class Users
{
    public Guid userId {get; set;}

    public string? userName {get; set;}

    public Users(){}

    public Users(string _userName)
    {
        userId = Guid.NewGuid();
        userName = _userName;
    }

}


