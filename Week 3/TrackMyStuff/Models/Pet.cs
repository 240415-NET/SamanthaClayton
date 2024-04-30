namespace TrackMyStuff.Models;

public class Pet : Item // Pet class inherits from our Item class
{
    public string name {get; set;}
    public string species {get; set;}
    public int age {get; set;}
    
    // Constructors
    public Pet (string _name, string _species, int _age) : base ()
    {
        name = _name;
        species = _species;
        age = _age;
        userId = 10;  //not sure if you would use .this or .base 
    }
    // Calling the base classes constructor
    //To do this, you need an all argument construcor in the base class
    public Pet  (int userId, int itemId, string category,
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