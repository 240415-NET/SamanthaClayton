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
    public async Task<Item>CreateNewItemAsync(Item newItemFromController)
    {
        await itemStorage.CreateNewItemInDBAsync(newItemFromController);
        return newItemFromController;

    }
    public async Task<List<Item>> GetAllItemsForUserAsync(Guid userIdFromController)
    {
        List<Item> foundItems = await itemStorage.GetAllItemsForUserFromDBAsync(userIdFromController);
        return foundItems;
    }

}