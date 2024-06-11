using ActivityTracker.Models;
using Microsoft.AspNetCore.Mvc;
using ActivityTracker.Services;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Configuration.UserSecrets;
using Azure.Identity;

namespace ActivityTracker.Controllers;

[ApiController]
//[Route("users")]

public class ActivityController : ControllerBase
{

    // Create an instance of the IActivityService interface 
    private readonly IActivityService _activityService;

    public ActivityController (IActivityService activityServiceFromBuilder)
    {
        _activityService = activityServiceFromBuilder;
    }

    [HttpPost("/Activity")]
    // Take in information about the activity from the front end 
    public async Task<ActionResult> PostNewActivity(string newActivityDescriptionFromFrontEnd,
                                                    DateOnly newActivityDateFromFrontEnd,
                                                    TimeOnly newActivityTimeFromFrontEnd,
                                                    string newActivityNameOfPersonFromFrontEnd,
                                                    string userNameToAddActivityToFromFrontEnd)
    {
        try
        {
            // Create a new Activity object & assign it the values provided by the front end
            Activity newActivityToAdd = new Activity();
            newActivityToAdd.activity_Description = newActivityDescriptionFromFrontEnd;  // description
            newActivityToAdd.Date_OfActivity = newActivityDateFromFrontEnd; // date
            newActivityToAdd.Time_OfActivity = newActivityTimeFromFrontEnd; // time
            newActivityToAdd.nameOfPerson = newActivityNameOfPersonFromFrontEnd; // name of person
            newActivityToAdd.user.userName = userNameToAddActivityToFromFrontEnd; // username

            // Pass that Activity object to the Service layer & AWAIT the asynchronous method
            Activity activityToReturn = await _activityService.CreateNewActivityAsync(newActivityToAdd);
            return Ok($"{activityToReturn.activity_Description} was created.");

        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost("/Post New Activity With UserId")]
    // Take in information about the activity from the front end 
    public async Task<ActionResult> PostNewActivityWithUserId(string newActivityDescriptionFromFrontEnd,
                                                    DateOnly newActivityDateFromFrontEnd,
                                                    TimeOnly newActivityTimeFromFrontEnd,
                                                    string newActivityNameOfPersonFromFrontEnd,
                                                    Guid userIdToAddActivityTo)
    {
        try
        {
            // Create a new Activity object & assign it the values provided by the front end
            Activity newActivityToAdd = new Activity();
            newActivityToAdd.activity_Description = newActivityDescriptionFromFrontEnd;  // description
            newActivityToAdd.Date_OfActivity = newActivityDateFromFrontEnd; // date
            newActivityToAdd.Time_OfActivity = newActivityTimeFromFrontEnd; // time
            newActivityToAdd.nameOfPerson = newActivityNameOfPersonFromFrontEnd; // name of person
            newActivityToAdd.user.userId = userIdToAddActivityTo; // userId

            // Pass that Activity object to the Service layer & AWAIT the asynchronous method
            Activity activityToReturn = await _activityService.CreateNewActivityWithUserIdAsync(newActivityToAdd);
            return Ok($"{activityToReturn.activity_Description} was created.");

        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("/Get")]
    public async Task<ActionResult<List<Activity>>> GetAllActivitiesByUserName(string username)
    {
        try
        {
            List<Activity> userActivitiesList = await _activityService.GetAllActivitiesByUserNameAsync(username);
            return Ok(userActivitiesList);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("/GetByUserId")]
    // Take in a userId from the front end and get the activities for that user
    public async Task<ActionResult<List<Activity>>> GetAllActivitiesByUserId(Guid userIdFromFrontEnd)
    {
        try
        {
            // Create a new list of Activity object and call the Service Layer to get the activities
            // AWAIT this asynchronous method
           // List<Activity> userActivitiesList = await _activityService.GetAllActivitiesByUserIdAsync(userIdFromFrontEnd);
            //return Ok(userActivitiesList);
            return Ok(await _activityService.GetAllActivitiesByUserIdAsync(userIdFromFrontEnd));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }


}
