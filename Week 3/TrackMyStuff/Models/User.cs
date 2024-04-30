namespace TrackMyStuff.Models;

public class User
{
    // Fields
    // This is an example of everaging the get; set; shorthand to protect
    // our fields/properties.  We can shift the burden of the
    // access modifier to the getter/setter and avoid having to write
    // more code to create a traditiona field and property.
    public int userId {get; private set;} // could also do = 1; here to default it to 1
    public string userName {get; private set;}

    // Constructors

    // Default/No-Argument Constructor
    public User() {}


    // This constructor takes two arguments
    public User(int _userId, string _userName)
    {
            userId = _userId;
            userName = _userName;
    }


}
