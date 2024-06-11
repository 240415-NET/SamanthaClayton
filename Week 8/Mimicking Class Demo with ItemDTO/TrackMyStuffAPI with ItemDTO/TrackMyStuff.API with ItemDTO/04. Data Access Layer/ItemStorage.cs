
using Microsoft.EntityFrameworkCore;
using TrackMyStuff.API.Models;

namespace TrackMyStuff.API.Data;

public class ItemStorage : IItemStorage
{
    private readonly TrackMyStuffContext context;
    public ItemStorage(TrackMyStuffContext _context)
    {
        context = _context;
    }
    public async Task<ItemUserIdDTO> CreateNewItemInDBAsync (ItemUserIdDTO newItemFromService)
    {
        User? userToAddItemTo = await context.Users.SingleOrDefaultAsync(user=> user.userId == newItemFromService.userId);
        Item itemToAddToDB = new Item(newItemFromService, userToAddItemTo);
        
        context.Add(itemToAddToDB);
        await context.SaveChangesAsync();
        return newItemFromService;
    }


        /*public async Task<List<Item>> GetAllItemsForUserFromDBAsyncNoDTO(Guid userIdFromService)
    {

        // Creating a new list and creating new itmes each time changes nohing

       // List<Item> newItemList = new List<Item>();
        //Item itemToAddToList = new Item();
        List<Item> returnedListFromDB = await context.Items
                                    //.Include(item => item.user)
                                    .Where(item =>item.user.userId == userIdFromService)
                                    .ToListAsync();
                                    */

        /*for (int i = 0; i < returnedListFromDB.Count; i++)
        {
            itemToAddToList = returnedListFromDB[i];
            newItemList.Add(itemToAddToList);
        }*/
        /*
        return returnedListFromDB;

    }
*/

    public async Task<List<ItemUserIdDTO>> GetAllItemsForUserFromDBAsync(Guid userIdFromService)
    {

        List<ItemUserIdDTO> foundItems = new List<ItemUserIdDTO>();
        List<Item> returnedListFromDB = await context.Items
                                    .Include(item => item.user)
                                    .Where(item =>item.user.userId == userIdFromService)
                                    .ToListAsync();

        for (int i = 0; i < returnedListFromDB.Count; i++)
        {
            ItemUserIdDTO itemUserIdDTOToAdd = new ItemUserIdDTO(returnedListFromDB[i]);
            foundItems.Add(itemUserIdDTOToAdd);
        }
        return foundItems;

    }
   public async Task<List<Item>> GetAllItemsForUserFromDBAsyncNoDTO(Guid userIdFromService)
    {

        List<Item> returnedListFromDB = await context.Items
                                    .Include(item => item.user)
                                    .Where(item =>item.user.userId == userIdFromService)
                                    .ToListAsync();


        return returnedListFromDB;

    }

}