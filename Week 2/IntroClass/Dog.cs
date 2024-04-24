using System.Xml.Serialization;

namespace IntroClass;

public class Dog
{
    //A class has members.
    //These members are fields (variables)
    //and methods (behaviors/things the animal does).

    //Fields

    //We need to give our fields (and methods) access modifiers
    //so we can control who gets to access them.
    //The most common are public, private, and internal, but
    //there are others.

    /* (most common to least common)
    public - access isn't restricted whatsover
    private - we can only see this from within our Class
    internal - access is limited to the current assembly
    protected - access is limited to this class or classes that inherit from the current class
    protected internal - access is limited to the current assembly or types derived from the containing class
    private protected - access is limited to the containing class ortypes derived from the containing class that are within the current assembly
    */

    //Instance Fields
    public string name {get; set;}
    public string breed {get; set;}
    public int age {get; set;}
    public string gender {get; set;}
    public double weight {get; set;}

    // Static Fields
    public static int legs = 4;
    public static bool hasTail = true;





    //Methods

    //This is an example of an instance method.  It is called via
    //dot notation from an instance of the class
    public void Bark()
    {
        Console.WriteLine($"{name}: bark bark!");
    }    

    //This is an example of a static method
    public static void DefineDog()
    {
        //The @ in front of the string turns it into a verbatim string
        //This lets us spread a long string across multiple lines of code
        Console.WriteLine(@"The dog is a domesticated descendant of the wolf
        It's derived from the extinct gray wolves.");
    }





}