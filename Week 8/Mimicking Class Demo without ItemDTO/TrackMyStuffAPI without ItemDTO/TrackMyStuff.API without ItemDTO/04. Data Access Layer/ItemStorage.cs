using System.Net.Mime;
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
    public async Task<Item> CreateNewItemInDBAsync (Item newItemFromService)
    {
        Item itemToAddToDB = new Item(newItemFromService.category,
                            newItemFromService.originalCost,
                            newItemFromService.purchaseDate,
                            newItemFromService.description,
                            newItemFromService.userId);
        context.Add(itemToAddToDB);
        await context.SaveChangesAsync();
        return newItemFromService;
    }


        public async Task<List<Item>> GetAllItemsForUserFromDBAsync(Guid userIdFromService)
    {

        List<Item> foundItems = new List<Item>();
        List<Item> returnedListFromDB = await context.Items
                                    //.Include(item => item.user)
                                    .Where(item =>item.userId == userIdFromService)
                                    .ToListAsync();

        for (int i = 0; i < returnedListFromDB.Count; i++)
        {
            Item itemUserIdDTOToAdd = returnedListFromDB[i];
            foundItems.Add(itemUserIdDTOToAdd);
        }
        return foundItems;

    }

}