namespace ActivityTracker.Models;

public class ActivityUserIdDTO
{
    public Guid userId {get; set;}
    public Guid activityId {get; set;}
    public string category {get; set;}
    public double originalCost {get; set;}
    public double purchaseDate {get; set;}
    public string description {get;set;}

    public ActivityUserIdDTO(){}
}