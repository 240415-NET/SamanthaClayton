// Pasting in code from the console app

namespace TrackMyStuff.API.Models; // Adding .API

public class Pet : Item // Pet class inherits from our Item class
{
    public string name {get; set;}
    public string? species {get; set;} // question mark allows this to be a string OR null
    public int? age {get; set;}
    
    // Constructors
    public Pet (): base() {}

    

    // Calling the base classes constructor
    //To do this, you need an all argument construcor in the base class
    public Pet  (Guid userId, Guid itemId, string category,
                double originalCost, DateTime purchaseDate,
                string description, string _name, string _species,
                int _age) : base (userId, itemId, category,
                originalCost, purchaseDate, description)
        {
            name = _name;
            species = _species;
            age = _age;
        }
    

}