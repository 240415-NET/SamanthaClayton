
using System.ComponentModel.DataAnnotations;

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
 
    public Activity(){}

    public Activity (string _activity_Description, string _nameOfPerson,
                DateOnly _Date_OfActivity, TimeOnly _Time_OfActivity,
                Guid _userId)
        {
        activityID = Guid.NewGuid();
        activity_Description = _activity_Description;
        nameOfPerson = _nameOfPerson;
        Date_OfActivity = _Date_OfActivity;
        Time_OfActivity = _Time_OfActivity;
        userId = _userId;
    }
    
    

}