using Microsoft.AspNetCore.Mvc;
using TrackMyStuff.API.Services;
using TrackMyStuff.API.Models;
using Microsoft.EntityFrameworkCore.Query.Internal;


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
    public async Task<ActionResult> PostNewItem(ItemUserIdDTO newItemToCreateFromFrontEnd)
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
    public async Task<ActionResult<List<ItemUserIdDTO>>> GetAllItemsForUserByUserId (Guid userIdFromFrontEnd)
    {
        try
        {
            List<ItemUserIdDTO> itemsFound = await itemService.GetAllItemsForUserAsync(userIdFromFrontEnd);
            return Ok(itemsFound);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("/Activity without ADTO")]
    public async Task<ActionResult<List<Item>>> GetAllItemsForUserByUserIdNoDTO (Guid userIdFromFrontEnd)
    {
        try
        {
            List<Item> itemsFound = await itemService.GetAllItemsForUserAsyncNoDTO(userIdFromFrontEnd);
            return Ok(itemsFound);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

}