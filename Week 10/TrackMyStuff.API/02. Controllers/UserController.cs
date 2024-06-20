//For a controller, we always want to bring in Microsoft.AspNetCore.Mvc
//This is where we get things like the ApiController annotation, and the ControllerBase class
using Microsoft.AspNetCore.Mvc;
using TrackMyStuff.API.Models;
using TrackMyStuff.API.DTOs;
using TrackMyStuff.API.Services;


namespace TrackMyStuff.API.Controllers;

// We are going to break out business logic into a Service layer outside of 
// our controllers, to keep them
// relatively small/lightweight.  Since the controllers in ASP.NET
//application ideally only handle receiving & returning HTTP requests.
[ApiController]
//[Route("[controller]")]
//[Route("Users")]

public class UserController : ControllerBase
{

    // I know that I am going to need at a minimum, a place to hold
    //my UserService object that will be given to me by the builder
    // when the app is dotnet run.
    // We are NOT going to instantiate this object within the controller
    // with the uusal Object myObject = new Object() style syntax.
    // We are going to allow the builder to handle creating and then
    //passing in that UserService object through the controller's
    // constructor.
    private readonly IUserService _userService;

    // Here is my constructor where we will take in our dependencies
    // that are automatically passed in the builder.
    public UserController(IUserService userServiceFromBuilder)
    {
        _userService = userServiceFromBuilder;
    }

    // Create a User in our DB
    // Here we are going to create our first controller method.  This method needs
    // a few things.  It needs an HTTP verb tag and a method signature
    // that incudes the "async" keyword. This method makes the method
    // asynchronous meaning that we won't lock up program executon across our entire
    // app waiting for someone's potentially slow internet to respond to us.
    [HttpPost("Users/{usernameFromSwagger}")] // Use post instead of Get because we're creating a user
    // Returns on the methods will look different because we're working with
    // asyncrhonous operations
    public async Task<ActionResult<User>> PostNewUser(string usernameFromSwagger) // We will return an ActionResult and it can return a User
    {
        // Inside of our controller, we are going to call a method from our
        // Service layer from the UserService class.
        // We are goign to wrap this in a try-catch so that if anything goes wrong
        // our entire API doesn't immediately go down and we can inform the uesr
        // that they've messed up

        try
        {
            User newUser = new User(usernameFromSwagger);
    
            // In our Service layer, we are going to create a method
            // CreateNewUserAsync.  Inside of our 'try' block here, in the Controller,
            // we are calling this method.  The service layer will handling that this
            // object meets our crtieria
            // Controller just knows it's going to send it to the Service layer.

            await _userService.CreateNewUserAsync(newUser);
            // Until the Task in the return is resolved, we're going to wait.


            // If it does, we return a 200-OK success message to the uesr and echo
            // back the object that they gave us.
            return Ok(newUser);

            // If for some reason the CreateNewUserAsync method fails,
            // we will hit the catch.

        } catch (Exception e) // If something goes wrong, we'll include a code to let them know something went wrong.
        // He recommends catching the exception and allow the exception message to make it to Swagger
        // If not, you'll have a hard time trying to debug your application.  It's not as
        // straightforward as debugging a Console app.
        {
            // If something goes wrong (user sends a bad request, etc.), we are going
            // to send a 400 bad request respond with the exception method it triggered
            // We're sending the 400 & inside of the body of the 400, we're including
            // the message.
            return BadRequest(e.Message);

        }

    }

    [HttpPost("/Users/list")]
    public async Task<ActionResult<List<string>>> PostListOfUsers(List<string> usernames)
    {
        //Inside of our controller, we are going to call a method from our Service layer, from the UserService class.
        //We are going to wrap this in a try-catch so that if anything goes wrong our entire API doesn't immediately go down
        //and we can inform the user that they've messed up.
        try
        {   
            foreach (string username in usernames)
            {
                User newUser = new User(username);
            
                await _userService.CreateNewUserAsync(newUser);
            }

            return Ok(usernames);
 
        } 
        catch(Exception e)
        {

            return BadRequest(e.Message);
        }
    }

    // Now we are going to write a GET method to return a single user
    // from our database based on the username passed in from 
    // Swagger/postman/thunderclient/etc or whatever our front-end
    // happens to be.

    [HttpGet("/Users/{userNameToFindFromFrontEnd}")]

    public async Task<ActionResult<User>> GetUserByUsername(string userNameToFindFromFrontEnd)
    {
        //We are goign to start with the try catch again so that we 
        // don't crash our API.  If something goes wrong,
        // we can inform the front end so it can inform the user

        try
        {
            return await _userService.GetUserByUsernameAsync(userNameToFindFromFrontEnd);
        }
        catch(Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpDelete("Users/{userNameToDeleteFromFrontEnd}")]
    public async Task<ActionResult> DeleteUserByUserNameAsync(string userNameToDeleteFromFrontEnd)
    {
        try
        {
            // We will call the delete method in our Service layer 
            await _userService.DeleteUserByUserNameAsync(userNameToDeleteFromFrontEnd);
            // don't need awai tbecause this method return is void ^^^

            // If all goes well, return a 200 Ok to the front end with a message
            // inside telling the user that the delete worked
            return Ok($"{userNameToDeleteFromFrontEnd} was deleted in the database!");
        }
        catch(Exception e)
        {
            return NotFound(e.Message); // a 404 not found with a message in it
        }
    }

    // Here we'll create an HTTP PATCH method for our controller
    // This method will update a user object on our DB in place
    // We are going to use it to update someone's username without having
    // to re-create a new user object.
    [HttpPatch("Users/")]
    public async Task<ActionResult> UpdateUserByUserName(UserNameUpdateDTO userNamesToSwap)
    {
        // small object that has old uesr name, new uesr name and it's wrapped up that we can easily
        // pass back and forth
        try
        {
            await _userService.UpdateUserNameAsync(userNamesToSwap);
            return Ok($"{userNamesToSwap.oldUserName}'s has been changed to {userNamesToSwap.newUserName}");
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    

}