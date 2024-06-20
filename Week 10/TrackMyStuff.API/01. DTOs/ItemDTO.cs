using TrackMyStuff.API.Models;

namespace TrackMyStuff.API.DTOs;

//Creating this because we don't want to have to provide a whole User object
// when we want t add an item becuase the item model has a whoel User in it
// The DTO helps us get away from having to do this in our front end and ideally we only
//have to deal with this in our data access layer
// Only used between front-end and the API
// DB doesn't care about it/doesn't know about it

public class ItemsDTO //specific to items, not pets/documents today, you can have a petDTO tht inherits this
{
    public Guid userId {get;set;}

    //we don't need the itemId because it's a guid that's not going to be gotten from the front end
// we could add item id now (after we add in the mappin constructor belw)
    public Guid itemId {get; set;}
    public string category {get; set;}
    public double originalCost {get; set;}
    public DateTime purchaseDate {get;set;}
    public string description {get; set;}

    public ItemsDTO() {}

    //Create a mapping constructor to generate ItemDTOs to send back
    // to our front end based on item model objects that come
    // back from our DB
    public ItemsDTO(Item item)
    {
        userId = item.user.userId;
        itemId = item.itemId;
        category = item.category;
        originalCost = item.originalCost;
        purchaseDate = item.purchaseDate;
        description = item.description;
    }
}

// all of this had to do with doing json serialization manually.
// the DTO will serve a way different purpose for us now.  so commenting all of this out.

/*public class ItemsDTO
{
    public List<Item>? Items {get; set;}
    public List<Document>? Documents {get; set;}
    public List<Pet>? Pets {get; set;}

    public ItemsDTO()
    {
        this.Items = new List<Item>();
        this.Documents = new List<Document>();
        this.Pets = new List<Pet>();
    }

}*/