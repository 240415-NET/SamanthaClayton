namespace TrackMyStuff.Models;

public class User
{
    // Fields
    // This is an example of everaging the get; set; shorthand to protect
    // our fields/properties.  We can shift the burden of the
    // access modifier to the getter/setter and avoid having to write
    // more code to create a traditiona field and property.

    // We are using a pre-built data type from the default
    // System library to generate a truly unique userId
    
    public Guid userId {get; private set;} // could also do = 1; here to default it to 1
    public string userName {get; private set;}

    // Constructors

    // Default/No-Argument Constructor
    // In reality, we probably don't want a no-arg constructor
    //in this case, but we're keeping it for demo
  
    public User() {}


    // This constructor takes one argument
    public User(string _userName)
    {
            userId = Guid.NewGuid(); // This creates a random Guid for us without us having to worry about it
            userName = _userName;
    }


}
