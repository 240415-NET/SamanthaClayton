using TrackMyStuff.API.Models;
using TrackMyStuff.API.DTOs;
using Microsoft.EntityFrameworkCore;

namespace TrackMyStuff.API.Data;

public class ItemStorageEFRepo : IItemStorageEFRepo
{
    private readonly TrackMyStuffContext _context;

    public ItemStorageEFRepo(TrackMyStuffContext context)
    {
        _context = context;
    }

    // In order to create this item in the DB,w e ned to do a little
    // more leg work because every item is associated with a user object
    public async Task<ItemsDTO> CreateNewItemInDBAsync (ItemsDTO newItemFromService)
    {
        // First we need ot reach into our DB for the user whose uesrID
        // corresponds to the one coming in from our DTO
        User? owner = await _context.Users.
            SingleOrDefaultAsync(user => user.userId == newItemFromService.userId);
        
        // Now we have to create an item object based on our model, we do not stick the DTO itself into the DB
        Item itemtoAdd = new(newItemFromService, owner);

        _context.Add(itemtoAdd);

        await _context.SaveChangesAsync();

        return newItemFromService;
        
    }

    public async Task<List<Item>> GetAllItemsForUserInDBAsync(Guid userIdFromService)
    {

        // Here we will ask the database for all items associated with the
        //user whose Guid matches the userIdFromService
        //using LINQ methods and lambdas
        return await _context.Items // We ask our contet for the collcetion of Item objects in the DB
        .Include(item => item.user) //we ask EF to also grab the associated user from the user table
        // Why do we bring in the user if the userId is on the item table?
        // What we're getting returns is the whole Item model (the whole User, itemId, category, etc.)
        .Where(item => item.user.userId == userIdFromService) // we then ask for every item whose owner's userId matches the userIdFromService
        .ToListAsync(); // finally, we turn those items into a list
    }

}
