using ActivityTracker.Models;
using ActivityTracker.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ActivityTracker.Services;

public class ActivityService : IActivityService
{

    private readonly IActivityStorageEFRepo activityStorageEFRepo;

    public ActivityService (IActivityStorageEFRepo _activityStorageEFRepoFromBuilder)
    {
        activityStorageEFRepo = _activityStorageEFRepoFromBuilder;
    }

    // Take the new activity passed in from the controller layer & send it to the data access layer
    public async Task<Activity> CreateNewActivityAsync(Activity newActivityToAddFromController)
    {
        // Call the data access layer to store this activity to the database
        // In the data access layer, we'll also retrieve the full User and put that on the object
        // So we'll get a complete activity object back
        //AWAIT the method because it's asynchronous
        Activity activityToReturn = await activityStorageEFRepo.CreateNewActivityInDBAsync(newActivityToAddFromController);

        // Return the complete activity that we stored to the database
        return activityToReturn;
    }

     public async Task<Activity> CreateNewActivityWithUserIdAsync(Activity newActivityToAddFromController)
    {
        // Call the data access layer to store this activity to the database
        // In the data access layer, we'll also retrieve the full User and put that on the object
        // So we'll get a complete activity object back
        //AWAIT the method because it's asynchronous
        Activity activityToReturn = await activityStorageEFRepo.CreateNewActivityWithUserIdInDBAsync(newActivityToAddFromController);

        // Return the complete activity that we stored to the database
        return activityToReturn;
    }

    public async Task<List<Activity>> GetAllActivitiesByUserNameAsync(string username)
    {
        return await activityStorageEFRepo.GetAllActivitiesbyUserNameFromDBAsync(username);
    }

    // Call the data access layer and pass it the userID
    public async Task<List<Activity>> GetAllActivitiesByUserIdAsync(Guid userIdFromController)
    {
        // AWAIT this asynchronous method
        return await activityStorageEFRepo.GetAllActivitiesbyUserIdFromDBAsync(userIdFromController);
    }


}

