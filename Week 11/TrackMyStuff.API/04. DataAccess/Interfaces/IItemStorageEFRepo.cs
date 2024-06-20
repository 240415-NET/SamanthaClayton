using TrackMyStuff.API.Models;
using TrackMyStuff.API.DTOs;

namespace TrackMyStuff.API.Data;

public interface IItemStorageEFRepo
{

    public Task<ItemsDTO> CreateNewItemInDBAsync (ItemsDTO newItemFromServce);
    public Task<List<Item>> GetAllItemsForUserInDBAsync(Guid userId);

}