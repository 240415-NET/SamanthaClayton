using Microsoft.AspNetCore.Mvc;
using TrackMyStuff.API.Services;
using TrackMyStuff.API.Models;


namespace TrackMyStuff.API.Controllers;

[ApiController]
[Route("[controller]")]

public class ItemController : ControllerBase
{
    private readonly IItemService itemService;
    public ItemController(IItemService _itemService)
    {
        itemService = _itemService;
    }

    [HttpPost]
    public async Task<ActionResult> PostNewItem(Item newItemToCreateFromFrontEnd)
    {
        try
        {
            await itemService.CreateNewItemAsync(newItemToCreateFromFrontEnd);
            return Ok($"{newItemToCreateFromFrontEnd.description} was created");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    
    [HttpGet]
    public async Task<ActionResult<List<Item>>> GetAllItemsForUserByUserId (Guid userIdFromFrontEnd)
    {
        try
        {
            List<Item> itemsFound = await itemService.GetAllItemsForUserAsync(userIdFromFrontEnd);
            return Ok(itemsFound);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

}