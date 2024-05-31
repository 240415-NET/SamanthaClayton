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
[Route("[controller]")]
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
    [HttpPost] // Use post instead of Get because we're creating a user
    // Returns on the methods will look different because we're working with
    // asyncrhonous operations
    public async Task<ActionResult<User>> PostNewUser(User newUserSentFromFrontEnd) // We will return an ActionResult and it can return a User
    {
        // Inside of our controller, we are going to call a method from our
        // Service layer from the UserService class.
        // We are goign to wrap this in a try-catch so that if anything goes wrong
        // our entire API doesn't immediately go down and we can inform the uesr
        // that they've messed up

        try
        {
            // In our Service layer, we are going to create a method
            // CreateNewUserAsync.  Inside of our 'try' block here, in the Controller,
            // we are calling this method.  The service layer will handling that this
            // object meets our crtieria
            // Controller just knows it's going to send it to the Service layer.

            await _userService.CreateNewUserAysnc(newUserSentFromFrontEnd);
            // Until the Task in the return is resolved, we're going to wait.


            // If it does, we return a 200-OK success message to the uesr and echo
            // back the object that they gave us.
            return Ok(newUserSentFromFrontEnd);

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

}