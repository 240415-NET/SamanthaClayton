namespace TrackMyStuff.API.Models;

public class Pet : Item //Pet inherits from our Item class as well
{
    public string name {get; set;}

    //Question mark allows this to be a string OR null
    public string? species {get; set;}
    public int? age {get; set;}

    // Constructors
    public Pet() {}
    // public Pet() : base() { } is the same
    


    // An example of calling the base class constructor (ALL POSSIBLE ARGUMENTS in this case)
    // Took out the Guid UserId from the Pet() args
    // Took out userId from the base() args
    public Pet(string category, double originalCost, 
        DateTime purchaseDate, string description, string _name, string _species, int _age) : 
        base(category, originalCost,purchaseDate, description)
        // In our Pet constructor, because there are things in the parent class Item, we call the base constructor and we pass those things at the same time

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