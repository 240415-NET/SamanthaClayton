
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace ActivityTracker.Models;
public class Activity
{

    [Key]
    public Guid activityID {get; set;}
    public string activity_Description {get;set;}
    public string nameOfPerson {get;set;}
    public DateOnly Date_OfActivity {get;set;}
    public TimeOnly Time_OfActivity {get;set;}
    public Guid userId {get; set;}
    public User user {get; set;} = new();

 
    public Activity(){}

    /*public Activity (string _activity_Description, string _nameOfPerson,
                DateOnly _Date_OfActivity, TimeOnly _Time_OfActivity)
        {
        activityID = Guid.NewGuid();
        activity_Description = _activity_Description;
        nameOfPerson = _nameOfPerson;
        Date_OfActivity = _Date_OfActivity;
        Time_OfActivity = _Time_OfActivity;
    }
    
    */
    public Activity (string _activity_Description, string _nameOfPerson,
                DateOnly _Date_OfActivity, TimeOnly _Time_OfActivity, Guid _userId)
        {
        activityID = Guid.NewGuid();
        activity_Description = _activity_Description;
        nameOfPerson = _nameOfPerson;
        Date_OfActivity = _Date_OfActivity;
        Time_OfActivity = _Time_OfActivity;
        userId = _userId;
    }
    

  /* public Activity (string _activity_Description, string _nameOfPerson,
                DateOnly _Date_OfActivity, TimeOnly _Time_OfActivity, User _user)
        {
        activityID = Guid.NewGuid();
        activity_Description = _activity_Description;
        nameOfPerson = _nameOfPerson;
        Date_OfActivity = _Date_OfActivity;
        Time_OfActivity = _Time_OfActivity;
        user = _user;
    }*/

   /* public Activity (Guid _activityId, string _activity_Description, string _nameOfPerson,
                DateOnly _Date_OfActivity, TimeOnly _Time_OfActivity,  Guid _userId, User _user)
        {
        activityID =  _activityId;
        activity_Description = _activity_Description;
        nameOfPerson = _nameOfPerson;
        Date_OfActivity = _Date_OfActivity;
        Time_OfActivity = _Time_OfActivity;
        userId = _userId;
        //user.userId = user.userId;
        user.userName= _user.userName;
        user.userEmail = _user.userEmail;
        user.user_FirstName = _user.user_FirstName;
        user.user_LastName = _user.user_LastName;
    }
    */


}