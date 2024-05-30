namespace DependencyInjectionExamples;

class Program
{
    static void Main(string[] args)
    {
        
        // Usage without DI
        var sandwichMaker_NO_DI = new SandwichMaker_NO_DI();
        sandwichMaker_NO_DI.MakeSandwich();
        
        // Usage with DI
        var bread = new Bread();
        var sandwichMaker_WITH_DI = new SandwichMaker_WITH_DI(bread);
        sandwichMaker_WITH_DI.MakeSandwich();
    }
}

// We have a class that makes a sandwich and it needs ingredients
public class Bread
{
    public void GetBread()
    {
    Console.WriteLine("Getting bread...");
    }
}

// Without dependency injection, we create the bread object inside of our class
public class SandwichMaker_NO_DI()
{
    private Bread bread = new Bread(); // Create a new bread object here in this class
    public void MakeSandwich()
    {
        bread.GetBread();
        Console.WriteLine("Making sandwich wthout DI...");
    }
}

// With dependency injection, we have the bread object passed to us in a constructor
public class SandwichMaker_WITH_DI()
{
    private Bread bread; 
    public SandwichMaker_WITH_DI(Bread _bread) : this() // The bread object gets passed to us 
    {
        this.bread = _bread;
    }

    public void MakeSandwich()
    {
        bread.GetBread();
        Console.WriteLine("Making sandwich with DI...");
    }
}
