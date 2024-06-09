/*
In our console application when we were decided to use
a DTO, it was because we were serializing and deserializing
json files manually. So the class members decided to make 
a DTO called ItemsDTO that had a list of items, a list of
document, and a list of pets inside of it.  It also had
a constructor that took no arguments and created new lists
of items, documents, and pets.

In this application, the DTO will serve a different purpose
for us.  So we're going to do it differently.

We have changed the Item model to include an entire User.
When we want an item, we don't want to have to provide
a whole User in order to work with that item.  The DTO
will help us avoid having to provide an entire User
in our front-end.  The DTO will only be used between the
front-end and the API.  The database doesn't know about this
DTO & doesn't care about it.

*/



namespace TrackMyStuff.API.Models;

public class ItemUserIdDTO
{
    public Guid userId {get; set;}
    public Guid itemId {get; set;}
    public string category {get; set;}
    public double originalCost {get; set;}
    public DateTime purchaseDate {get; set;}
    public string description {get; set;}

    public ItemUserIdDTO(){}

    /* We'll also create a mapping constructor to generate
    ItemDTOs to send back to our front end based on item
    model objects that come back from our DB.  We use this
    when we get all items from a user.  In swagger, the user
    enters a userId and then we go to the database to get items.
    When we get the items, we convert them to an ItemUesrIdDTO. */

   public ItemUserIdDTO(Item item)
    {
        userId = item.user.userId;
        itemId = item.itemId;
        category = item.category;
        originalCost = item.originalCost;
        purchaseDate = item.purchaseDate;
        description = item.description;
    }

}