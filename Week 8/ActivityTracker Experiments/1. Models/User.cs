using System.ComponentModel.DataAnnotations;


namespace ActivityTracker.Models;
public class User
{
    [Key]
    public Guid userId {get; set;}
    public string userName {get; set;} = string.Empty;
    public string userEmail {get; set;} = string.Empty;
    public string user_FirstName {get; set;} = string.Empty;
    public string user_LastName {get; set;} = string.Empty;

    public List<Activity> activitys {get; set;} = new();
 
    public User(){}
    public User(string _userName)
    {
        userId = Guid.NewGuid();
        userName = _userName;
        userEmail = "";
        user_FirstName = "";
        user_LastName = "";
    }


}
