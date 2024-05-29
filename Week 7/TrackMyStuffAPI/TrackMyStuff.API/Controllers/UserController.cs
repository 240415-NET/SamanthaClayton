// For a contorller, we always want to bring in the Microsot.AspNetcore.Mvc
// This is where we get things like the ApiController annotation and 
// the ControllerBase class

using Microsoft.AspNetCore.Mvc;
using TrackMyStuff.API.Models;
using TrackMyStuff.API.DTOs;

namespace TrackMyStuff.API.Controllers;

[ApiController]
[Route("[controller]")]

public class UserController : ControllerBase
{
    public UserController(){}

}