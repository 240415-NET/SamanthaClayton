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
    public ActivityStorageEFRepo(DataContext dataContextFromBuilder, IUserStorageEFRepo userStorageEFRepoFromBuilder)
    {
        dataContext = dataContextFromBuilder;
    }


    public async Task<Activity> CreateNewActivityInDBAsync (Activity newActivityToAddFromActivityService)
    {

        // Get the full user from the Users table based on the Activity object's username
        User? fullUserWhoseActivityIsBeingAdded = await dataContext.Users.SingleOrDefaultAsync(user => user.userName == newActivityToAddFromActivityService.user.userName);
        //User fullUserWhoseActivityIsBeingAdded = new User();
        /*try
        {
            fullUserWhoseActivityIsBeingAdded = await UserStorageEFRepo.GetUserByUserNameFromDBAsync(newActivityToAddFromActivityService.user.userName);
            if (fullUserWhoseActivityIsBeingAdded == null)
            {
            throw new Exception ("User was not found in the database.  The user you searched for in the database is " + newActivityToAddFromActivityService.user.userName);
            }
        }
        catch (Exception e)
        {
            throw new Exception(e.Message + "Issue with retrieving the user from the database. The user you searched for in the database is " + newActivityToAddFromActivityService.user.userName);
        }
*/
        // When we get the full user back from the User table, assign it as the User in the Activity object
        Activity freshActivity = new Activity(newActivityToAddFromActivityService.activity_Description,
                                        newActivityToAddFromActivityService.nameOfPerson,
                                        newActivityToAddFromActivityService.Date_OfActivity,
                                        newActivityToAddFromActivityService.Time_OfActivity,
                                        fullUserWhoseActivityIsBeingAdded.userId);
//        newActivityToAddFromActivityService.user = fullUserWhoseActivityIsBeingAdded;

        // Now that the Activity object has all activity info and the full user information, add it to the database
        dataContext.Add(freshActivity);

        // Save the changes to the database & AWAIT this method because it's asynchronous
        await dataContext.SaveChangesAsync();

        // Return the activity object (which should now have all User information on it)
        return newActivityToAddFromActivityService;
    }


 public async Task<Activity> CreateNewActivityWithUserIdInDBAsync (Activity newActivityToAddFromActivityService)
    {

        User? userToAddItemTo = await dataContext.Users.SingleOrDefaultAsync(user=> user.userId == newActivityToAddFromActivityService.user.userId);
        
        if (userToAddItemTo == null)
        {
            throw new Exception ("User could not be found in database.");
        }
        
        // If you have the WHOLE user on the activity model,
        // then you need the WHOLE user when you add it to the
        // database even if userId is the only thing in the
        // activity table.
        newActivityToAddFromActivityService.user = userToAddItemTo;

        // Now that the Activity object has all activity info and the full user information, add it to the database
        dataContext.Add(newActivityToAddFromActivityService);

        // Save the changes to the database & AWAIT this method because it's asynchronous
        await dataContext.SaveChangesAsync();

        // Return the activity object (which should now have all User information on it)
        return newActivityToAddFromActivityService;
    }
    public async Task<List<Activity>> GetAllActivitiesbyUserNameFromDBAsync(string username)
    {
        // Make an empty list of activities
        List<Activity> userActivitiesListFromDB = new List<Activity>();
        
        // Get the full User object based on the user name
        User? fullUserWhoseActivityIsBeingRetrieved = await dataContext.Users.SingleOrDefaultAsync(user => user.userName == username);
        
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
        List<Activity> returnedListFromDB = await dataContext.Activity
            .Include(activity=> activity.user)
            .Where(activity=>activity.user.userId == userIdToSearchFor)
            .ToListAsync();
        for (int i = 0; i <returnedListFromDB.Count; i++)
        {
            userActivitiesListFromDB.Add(returnedListFromDB[i]);
        }
        return userActivitiesListFromDB;
    }


      /*  public async Task<List<Activity>> GetAllActivitiesbyUserIdFromDBAsync(Guid userId)
    {
        // Make an empty list of activities
        //List<Activity> userActivitiesListFromDB = new List<Activity>();


        // Fill the list of activities with info
        // Get the activities from the activities table where
        // the userId matches the one we're looking for
        // and send that back as a list*/
        /*userActivitiesListFromDB = await dataContext.activities // Ask the context for the collection of activities in the database
            .Where(activity => activity.user.userId == userIdToSearchFor) // Get every activity who's userId matches the one we want
            .ToListAsync(); // Turn those items into a list
        */

    /*    List<Activity> newList = new List<Activity>();
        

        // AWAIT this asynchronous method
        List<Activity> returnedListFromDB = await dataContext.Activity
            //.Include(activity=> activity.user.userId)
            .Where(activity=>activity.user.userId == userId)
            .ToListAsync();
       
       for (int i = 0; i <returnedListFromDB.Count; i++)
        {
            Activity activityToAdd = new(returnedListFromDB[i].activity_Description,
                returnedListFromDB[i].nameOfPerson,
                returnedListFromDB[i].Date_OfActivity,
                returnedListFromDB[i].Time_OfActivity,
                returnedListFromDB[i].user.userId);
            newList.Add(activityToAdd);
        }
        return newList;
        //return returnedListFromDB;
    }
*/

    public async Task<List<Activity>> GetAllActivitiesbyUserIdFromDBAsync(Guid userId)
    {


        List<Activity> newList = new List<Activity>();
        

        // AWAIT this asynchronous method
        List<Activity> returnedListFromDB = await dataContext.Activity
            .Include(activity=> activity.user)
            .Where(activity=>activity.user.userId == userId)
            .ToListAsync();
       
      /* for (int i = 0; i <returnedListFromDB.Count; i++)
        {
            Activity activityToAdd = new(returnedListFromDB[i].activity_Description,
                returnedListFromDB[i].nameOfPerson,
                returnedListFromDB[i].Date_OfActivity,
                returnedListFromDB[i].Time_OfActivity,
                returnedListFromDB[i].user = returnL);
            newList.Add(activityToAdd);
        }
        return newList;*/
        return returnedListFromDB;
    }

}