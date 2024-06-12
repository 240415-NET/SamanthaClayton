using ActivityTracker.Models;
namespace ActivityTracker.Data;

public interface IActivityStorageEFRepo
{
    public Task<ActivityDTO> CreateActivityInDBAsync(ActivityDTO dto, string userName);

    public Task<string> DeleteActivityByActivityNameFromDBAsync(string activityDescriptionToDelete, string userName);
    public Task<string> DeleteActivityByActivityIdFromDBAsync(Guid activityIdToDelete);
     public Task<string> UpdateActivityByActivityIdFromDBAsync(Guid activityIdToUpdateFromService);
    public Task<List<Activity>> GetAllActivitiesForUserFromDBAsync(string userNameFromController);
}