//For a controller, we always want to bring in Microsoft.AspNetCore.Mvc
//This is where we get things like the ApiController annotation, and the ControllerBase class
using Microsoft.AspNetCore.Mvc;
using TrackMyStuff.API.Models;
using TrackMyStuff.API.Services;
using TrackMyStuff.API.DTOs;

namespace TrackMyStuff.API.Controllers;

[ApiController]
//[Route("[controller]")]  he wants to set it on ecach individual method, just a preference
public class ItemController : ControllerBase
{

    private readonly IItemService _itemService;

    public ItemController(IItemService itemServiceFromBuilder)
    {
        _itemService = itemServiceFromBuilder;
    }
    
    [HttpPost("/Item")]
    public async Task<ActionResult> PostNewItem(ItemsDTO newItem)
    {
        try
        {
            await _itemService.CreateNewItemAsync(newItem);
            return Ok($"{newItem.description} was created");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("/Items")]
    public async Task<ActionResult<List<ItemsDTO>>> GetAllItemsForUser(Guid userId)
    {
        try 
        {
            // Creating a list to eventually return to our front end
            List<ItemsDTO> itemsFound = await _itemService.GetAllItemsForUserAsync(userId);
            return Ok(itemsFound);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}