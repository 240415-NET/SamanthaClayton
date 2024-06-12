using ActivityTracker.Models;

namespace ActivityTracker.Data;

public class ActivityDTO
{
    
    public string activity_Description {get;set;} 
    public string nameOfPerson {get;set;}
    public string Date_OfActivity {get; set;}
    public string Time_OfActivity {get; set;}
    public ActivityDTO(){}


    public ActivityDTO(Activity activity)
    {
        
        activity_Description = activity.activity_Description;
        nameOfPerson = activity.nameOfPerson;
        Date_OfActivity = activity.Date_OfActivity.ToString();
        Time_OfActivity = activity.Time_OfActivity.ToString();
       
    }

}