using TrackMyStuff.API.Models;

namespace TrackMyStuff.API.Data;

public interface IItemStorage
{

    public Task<Item> CreateNewItemInDBAsync (Item newItemFromServce);
    public Task<List<Item>> GetAllItemsForUserFromDBAsync(Guid userIdFromService);

}