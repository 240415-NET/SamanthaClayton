using System.Runtime.CompilerServices;
using TrackMyStuff.API.Data;
using TrackMyStuff.API.Models;

namespace TrackMyStuff.API.Services;

public class ItemService : IItemService
{
    private readonly IItemStorage itemStorage;
    public ItemService(IItemStorage _itemStorage)
    {
        itemStorage = _itemStorage;
    }
    public async Task<ItemUserIdDTO>CreateNewItemAsync(ItemUserIdDTO newItemFromController)
    {
        await itemStorage.CreateNewItemInDBAsync(newItemFromController);
        return newItemFromController;

    }

    public async Task<List<ItemUserIdDTO>> GetAllItemsForUserAsync(Guid userIdFromController)
    {
        List<ItemUserIdDTO> foundItems = await itemStorage.GetAllItemsForUserFromDBAsync(userIdFromController);
        return foundItems;
    }

}