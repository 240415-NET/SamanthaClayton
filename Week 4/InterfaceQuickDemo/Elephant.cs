namespace InterfaceQuickDemo;

// Implementing an interface LOOKS a lot like inheriting a base class.
// This is another reason the leading capital "I" can be important. So we know
// what classes we're inheriting vs. what interfaces we're implementing.

// Additionally, convention is that we put the base classes we inherit from first
// and then list our interfaes fi any.
public class Elephant : Animal, INoise// we inherit from Animal & implement the interface INoise
{

    public string subSpecies {get; set;}
    public int trunkLength {get; set;}

    //These are my methods I contractually MUST implement because I used the INoise
    //interface.  Every class that uses INoise can have its own unique implementation
    //of the methods within it, but it has to implement the method somehow.

    
    public void MakeSadNoise()
    {
        Console.WriteLine("sad elephant sounds");
    }

    public void MakeGeneralNoise()
    {
        Console.WriteLine("general elephant sounds");
    }


//If a base class you inherit already satisfies the requiremnet for a method
//that comes in from an interface, you don't necessarily have to define it in a
//derived class that implements that interface


    
}