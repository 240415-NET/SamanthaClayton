using TrackMyStuff.API.Models;
using TrackMyStuff.API.DTOs;

namespace TrackMyStuff.API.Services;

public interface IItemService
{


    public Task<ItemsDTO>CreateNewItemAsync(ItemsDTO newItemFromController);
    public Task<List<ItemsDTO>> GetAllItemsForUserAsync(Guid userIdFromController);

}