using System.Reflection.Metadata.Ecma335;
using ActivityTracker.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;
using System.Linq;

namespace ActivityTracker.Data;

public class ActivityStorageEFRepo : IActivityStorageEFRepo
{
    private readonly DataContext _dataContext;
    public ActivityStorageEFRepo(DataContext contextFromBuilder)
    {
        _dataContext = contextFromBuilder;
    }

    public async Task<ActivityDTO> CreateActivityInDBAsync(ActivityDTO activityDTO, string userName)
    {
        User owner = await _dataContext.users.SingleOrDefaultAsync(
            user => user.userName == userName);
        Activity newActivity = new(activityDTO, owner);

        _dataContext.activities.Add(newActivity);
        await _dataContext.SaveChangesAsync();
        return activityDTO;
    }

    public async Task<string> DeleteActivityByActivityNameFromDBAsync(string activityDescriptionToDelete, string userName)
    {
        User userToDeleteFrom = await _dataContext.users.SingleOrDefaultAsync(user=>user.userName == userName);
        Guid userIdToDeleteFrom = userToDeleteFrom.userId;

        List<Activity> userActivitiesFromDB = new List<Activity>();

        userActivitiesFromDB = await _dataContext.activities // Ask the context for the collection of activities in the database
            .Where(activity => activity.user.userId == userIdToDeleteFrom) // Get every activity who's userId matches the one we want
            .ToListAsync(); // Turn those items into a list

        Activity activityToDelete = userActivitiesFromDB.SingleOrDefault(activity=>activity.activity_Description == activityDescriptionToDelete);
        
        _dataContext.activities.Remove(activityToDelete);
        await _dataContext.SaveChangesAsync();
        return activityDescriptionToDelete;

    }

    public async Task<string> DeleteActivityByActivityIdFromDBAsync(Guid activityIdToDelete)
     {
        Activity activityToDelete = await _dataContext.activities.SingleOrDefaultAsync(activity => activity.activityID == activityIdToDelete);
        _dataContext.activities.Remove(activityToDelete);
        await _dataContext.SaveChangesAsync();
        return activityToDelete.activity_Description;
    }

    public async Task<string> UpdateActivityByActivityIdFromDBAsync(Guid activityIdToUpdateFromService)
    {
        Activity activityToUpdate = await _dataContext.activities.SingleOrDefaultAsync(activity => activity.activityID == activityIdToUpdateFromService);
        if (activityToUpdate == null)
            throw new Exception($"Activity Id \"{activityIdToUpdateFromService}\" was not found in the database.");
        
        activityToUpdate.isComplete = true;
        await _dataContext.SaveChangesAsync();
        return activityToUpdate.activity_Description;
    }

    public async Task<List<Activity>> GetAllActivitiesForUserFromDBAsync(string userNameFromService)
    {
        //Here we will ask the database for all items associated with the user who's guid matches
        //the userIdFromService, using LINQ methods (and lambdas :c )

        return await _dataContext.activities //So we ask our context for the collection of Item objects in the database
            .Include(item => item.user) //We ask entity framework to also grab the associated User object from the User table
            .Where(item => item.user.userName == userNameFromService) //We then ask for every item who's owner's UserId matches the userIdFromService
            .ToListAsync(); //Finally, we turn those items into a list
}
}