using TrackMyStuff.API.Models;

namespace TrackMyStuff.API.Data;

public interface IItemStorage
{

    public Task<ItemUserIdDTO> CreateNewItemInDBAsync (ItemUserIdDTO newItemFromServce);
    public Task<List<ItemUserIdDTO>> GetAllItemsForUserFromDBAsync(Guid userIdFromService);

    public Task<List<Item>> GetAllItemsForUserFromDBAsyncNoDTO(Guid userIdFromService);

}