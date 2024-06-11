using TrackMyStuff.API.Models;

namespace TrackMyStuff.API.Services;

public interface IItemService
{
    public Task<ItemUserIdDTO>CreateNewItemAsync(ItemUserIdDTO newItemFromController);
    public Task<List<ItemUserIdDTO>> GetAllItemsForUserAsync(Guid userIdFromController);

        public Task<List<Item>> GetAllItemsForUserAsyncNoDTO(Guid userIdFromController);

}