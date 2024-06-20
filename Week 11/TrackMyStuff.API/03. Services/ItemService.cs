using TrackMyStuff.API.DTOs;
using TrackMyStuff.API.Data;

namespace TrackMyStuff.API.Services;

public class ItemService: IItemService
{

    private readonly IItemStorageEFRepo _itemStorage;
    public ItemService(IItemStorageEFRepo efRepoFromBuilder)

    {
        _itemStorage = efRepoFromBuilder;
    }

    public async Task<ItemsDTO>CreateNewItemAsync(ItemsDTO newItemFromController)
    {
        await _itemStorage.CreateNewItemInDBAsync(newItemFromController);
        return newItemFromController;
    }

    public async Task<List<ItemsDTO>> GetAllItemsForUserAsync(Guid userIdFromController)
    {
        List<ItemsDTO> foundItems = new();
        // We know we will get SOMETHING back from the data access layer
        // I've got some assumptions about what it is, but let's say I'm a little lazy
        // We can leverage "var" to make things easier for us.
        var resultList = await _itemStorage.GetAllItemsForUserInDBAsync(userIdFromController);

    
        foreach (var item in resultList)
        {
            // For each item model objet in our result list, we will call tha tmapping consturctor 
            // that takes an item and uses it to create an ItemDTO for us.  Then it adds 
            // that new itemDTO object to th efoundItems list we ceated above
            foundItems.Add(new ItemsDTO(item));
        }

        return foundItems;

    }

}