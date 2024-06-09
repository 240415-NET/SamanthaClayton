/*
When converting from a console application to a Web API
& using Entity Framework Core (EF Core), we copied & pasted
the models and then made some minor changes:
1. We modified the namespace
2. For EF Core, we already happened to have
    a no-argument constructor so that EF Core
    can create the models during databsse
    operations (so we didn't have to make one)
3. For EF Core, we no longer want to have UserId in our
    items/documents/pets.  So we removed the UserId attribute
    from Items and then here we need to remove it from
    our constructor here in Pet.  We remove
    "Guid userId" from the Pet() portion &
    remove "userId" from the base() portion.
*/

// 1. MODIFY THE NAMESPACE
namespace TrackMyStuff.API.Models;

public class Pet : Item 
{
    public string name {get; set;}
    public string? species {get; set;}
    public int? age {get; set;}

// 2. A NO-ARGS CONSTRUCTOR WAS ALREADY HERE (NO CHANGE NEEDED)
    public Pet () {}

    
// 3. REMOVE "Guid userId" & "userId" FROM THIS CONSTRUCTOR

    public Pet(string category, double originalCost, 
                DateTime purchaseDate, string description,
                string _name, string _species, int _age) : 
                base(category, originalCost,purchaseDate,
                description)
    {
        name = _name;
        species = _species;
        age = _age;
    }


     public override string ToString()
    {
        return $"Category: {category}\nOriginal Cost: {originalCost}\nPurchase Date: {purchaseDate}\nDescription: {description}\nSpecies: {species}\nPet Name: {name}\nPet Age: {age}";
    }
    

}