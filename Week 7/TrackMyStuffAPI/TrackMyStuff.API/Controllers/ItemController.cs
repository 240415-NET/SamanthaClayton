// For a contorller, we always want to bring in the Microsot.AspNetcore.Mvc
// This is where we get things like the ApiController annotation and 
// the ControllerBase class

using Microsoft.AspNetCore.Mvc;
using TrackMyStuff.API.Models;
using TrackMyStuff.API.DTOs;

namespace TrackMyStuff.API.Controllers;

[ApiController]
[Route("[controller]")]

public class ItemController : ControllerBase
{
    public ItemController(){}

    /* This is an ugly way of getting the item to show up
     in Swagger, but it's something we'll actually do
     private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public ItemController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecastinItem")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }*/

}