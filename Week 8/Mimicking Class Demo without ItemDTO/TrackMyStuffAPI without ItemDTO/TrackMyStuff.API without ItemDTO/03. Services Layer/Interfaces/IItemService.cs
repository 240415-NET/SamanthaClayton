using TrackMyStuff.API.Models;

namespace TrackMyStuff.API.Services;

public interface IItemService
{
    public Task<Item>CreateNewItemAsync(Item newItemFromController);
    public Task<List<Item>> GetAllItemsForUserAsync(Guid userIdFromController);

}