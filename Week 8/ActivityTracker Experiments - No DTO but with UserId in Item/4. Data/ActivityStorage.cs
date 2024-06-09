using ActivityTracker.Models;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;
namespace ActivityTracker.Data;
public class ActivityStorageEFRepo : IActivityStorageEFRepo
{
    private readonly DataContext dataContext;
    public ActivityStorageEFRepo(DataContext dataContextFromBuilder)
    {
        dataContext = dataContextFromBuilder;
    }

    public async Task<Activity> CreateNewActivityInDBAsync (Activity newActivityToAddFromActivityService)
    {
        //User? fullUserWhoseActivityIsBeingAdded = await dataContext.users.SingleOrDefaultAsync(user => user.userName == newActivityToAddFromActivityService.user.userName);
        //newActivityToAddFromActivityService.user = fullUserWhoseActivityIsBeingAdded;
  
        dataContext.Add(newActivityToAddFromActivityService);

        await dataContext.SaveChangesAsync();
        return newActivityToAddFromActivityService;
    }

    public async Task<List<Activity>> GetAllActivitiesbyUserNameFromDBAsync(string username)
    {
        // Make an empty list of activities
        List<Activity> userActivitiesListFromDB = new List<Activity>();
        
        // Get the full User object based on the user name
        User? fullUserWhoseActivityIsBeingRetrieved = await dataContext.users.SingleOrDefaultAsync(user => user.userName == username);
        
        if(fullUserWhoseActivityIsBeingRetrieved == null)
        {
            throw new Exception("User name does not exist in the database.");
        }
        
        // Get the userId for this user
        Guid userIdToSearchFor = fullUserWhoseActivityIsBeingRetrieved.userId;
        
        // Fill the list of activities with info
        // Get the activities from the activities table where
        // the userId matches the one we're looking for
        // and send that back as a list
        /*userActivitiesListFromDB = await dataContext.activities // Ask the context for the collection of activities in the database
            .Where(activity => activity.user.userId == userIdToSearchFor) // Get every activity who's userId matches the one we want
            .ToListAsync(); // Turn those items into a list
        */
        List<Activity> returnedListFromDB = await dataContext.activities
           // .Include(activity=> activity.userId)
            .Where(activity=>activity.userId == userIdToSearchFor)
            .ToListAsync();
        for (int i = 0; i <returnedListFromDB.Count; i++)
        {
            userActivitiesListFromDB.Add(returnedListFromDB[i]);
        }
        return userActivitiesListFromDB;
    }


        public async Task<List<Activity>> GetAllActivitiesbyUserIdFromDBAsync(Guid userId)
    {
        // Make an empty list of activities
        List<Activity> userActivitiesListFromDB = new List<Activity>();


        // Fill the list of activities with info
        // Get the activities from the activities table where
        // the userId matches the one we're looking for
        // and send that back as a list
        /*userActivitiesListFromDB = await dataContext.activities // Ask the context for the collection of activities in the database
            .Where(activity => activity.user.userId == userIdToSearchFor) // Get every activity who's userId matches the one we want
            .ToListAsync(); // Turn those items into a list
        */
        List<Activity> returnedListFromDB = await dataContext.activities
            //.Include(activity=> activity.userId)
            .Where(activity=>activity.userId == userId)
            .ToListAsync();
        for (int i = 0; i <returnedListFromDB.Count; i++)
        {
            userActivitiesListFromDB.Add(returnedListFromDB[i]);
        }
        return userActivitiesListFromDB;
    }

}