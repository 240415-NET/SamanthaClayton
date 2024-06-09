/*
When converting from a console application to a Web API
& using Entity Framework Core (EF Core), we copied & pasted
the models and then made some minor changes:
1. We modified the namespace
2. For EF Core, we removed "UserId" as a property/attribute/field in Item
3. For EF Core, we added "User" as a property/attribute/field in Item
4. For EF Core, we used data annotations to set itemId as the primary key
5. Eventually, we'll need a mapping constructor when we do DTOs.
    When we add the DTO stuff, it will make the full argument constructor
    we already have for Item no longer be used throughout our program.
*/

// ADD THIS USING STATEMENT SO WE CAN DO CHANGE 4
using System.ComponentModel.DataAnnotations;

// 1. MODIFY THE NAMESPACE
namespace TrackMyStuff.API.Models;

public class Item
{
    // 2. REMOVE userId
    // public Guid userId {get; set;}

    // 3. ADD User
        /* We never want there to be an item without an associated
        user. Jonathan thinks if you take out the =new();, it would
        work just fine, but he prefers it there.*/
    public User user {get;set;} = new();

    // 4. USE DATA ANNOTATON TO SET itemID AS PRIMARY KEY
    [Key]
    public Guid itemId {get; set;}
    public string category {get; set;}
    public double originalCost  {get; set;}
    public DateTime purchaseDate {get; set;}
    public string description {get; set;}
    public Item (){}

    /*
    5. For our convenience (not for EF), we create this
        this mapping constructor. It allows us to create
        an item out of an ItemsDTO and a user object.
   */
    public Item(ItemUserIdDTO item, User owner)
    {
        user = owner;
        itemId = Guid.NewGuid();
        category = item.category;
        originalCost = item.originalCost;
        purchaseDate = item.purchaseDate;
        description = item.description;
    }


    public Item (string _category, double _originalCost, DateTime _purchaseDate, string _description)
    {
        itemId = Guid.NewGuid();
        category = _category;
        originalCost = _originalCost;
        purchaseDate = _purchaseDate;
        description = _description;
    }

    public override string ToString()
    {
        return $"Category: {category}\nOriginal Cost: {originalCost}\nPurchase Date: {purchaseDate}\nDescription: {description}";
    }
    public string AbbrToString()
    {
        return String.Format("Description: {0,-25}   Purchase Date: {1,10:d}   Original Cost: {2,-12:C2}",description,purchaseDate,originalCost);
    }


}