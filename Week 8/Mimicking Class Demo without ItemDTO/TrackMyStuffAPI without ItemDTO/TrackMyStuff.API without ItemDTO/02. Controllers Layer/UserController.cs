// For a contorller, we always want to bring in the Microsot.AspNetcore.Mvc
// This is where we get things like the ApiController annotation and 
// the ControllerBase class

using Microsoft.AspNetCore.Mvc;
using TrackMyStuff.API.Models;
using TrackMyStuff.API.Services;

namespace TrackMyStuff.API.Controllers;

[ApiController]
[Route("[controller]")]

public class UserController : ControllerBase
{
    private readonly IUserService userService;
    public UserController(IUserService _userService)
    {
        userService = _userService;
    }

    [HttpPost]
    public async Task<ActionResult<User>> PostNewUser(string userNameToCreateFromFrontEnd)
    {
        try
        {
            User newUser = new User(userNameToCreateFromFrontEnd);
            await userService.CreateNewUserAsync(newUser);
            return Ok(newUser);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    public async Task<ActionResult<User>> GetUserByUserName (string userNameToFindFromFrontEnd)
    {
        try
        {
            User foundUser = await userService.GetUserByUserNameAsync(userNameToFindFromFrontEnd);
            return Ok(foundUser);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPatch]
    public async Task<ActionResult<User>> UpdateUserByUserName (UserNameUpdateDTO userNamesToSwapFromFrontEnd)
    {
        try
        {
            await userService.UpdateUserNameAsync(userNamesToSwapFromFrontEnd);
            return Ok($"{userNamesToSwapFromFrontEnd.oldUserName} has been changed to {userNamesToSwapFromFrontEnd.newUserName}");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    
    [HttpDelete]
    public async Task<ActionResult<User>> DeleteUserByUserName (string userNameToDeleteFromFrontEnd)
    {
        try
        {
            await userService.DeleteUserByUserNameAsync(userNameToDeleteFromFrontEnd);
            return Ok($"{userNameToDeleteFromFrontEnd} has been deleted in the database");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }


}