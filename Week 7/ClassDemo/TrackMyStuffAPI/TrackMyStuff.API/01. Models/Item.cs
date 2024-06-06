using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TrackMyStuff.API.DTOs;


namespace TrackMyStuff.API.Models;

public class Item
{

   //START CHANGES FOR EF CORE
   // public Guid userId {get; set;}
   public User user {get; set;} = new(); //we never want
   //there to be an item without an associated user//
   // he thinks you could take out the = new(); and
   //it would work just fine, but he prefers it there
    
    // Here we are using data annotations to se itemId as the primary
    [Key]
    //END CHANGES FOR EF CORE
    public Guid itemId {get; set;}
    public string category {get; set;}
    public double originalCost {get; set;}
    public DateTime purchaseDate {get; set;}
    public string description {get; set;}

    //Constructors 
    public Item() { }
    
    //Creating a mapping constructor to map an item from an itemDTO and a user object
    // this is for our convenience, entity framework wont touch this, but we will
    public Item(ItemsDTO item, User owner)
    {
        user = owner; 
        itemId = Guid.NewGuid();
        category = item.category;
        originalCost = item.originalCost;
        purchaseDate = item.purchaseDate;
        description = item.description;    
    }
    // Took out Guid userId from the Item() args
    // Took out userId = _userId; from the Item() {} cod eblock
    
    // This is my full argument constructor.  In our API rendition of 
    //track my stuff, it is vestigial and odens't relaly do anything.
    public Item(string _category, double _originalCost, 
        DateTime _purchaseDate, string _description) {

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