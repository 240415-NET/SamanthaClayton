using System.ComponentModel.DataAnnotations;
namespace TrackMyStuff.API.Models;

public class User 
{
    //Fields
    
    //This is an example of leveraging the get;set; shorthand to protect our fields/properties
    //We can shift the burden of the access modifier to the getter or setter, and avoid having
    //to write more code to create a traditional field and property

    //We are using a prebuilt data type from the default System library to generate a truly unique
    //userId

    // Here we are using data annotations to se itemId as the primary
    [Key]
    public Guid userId {get; set;}
    public string userName {get; set;}

    // CHANGING THIS FOR EF CORE
    // Users can have many items/pets/documents
    // Each one of those items belong to 1 user
    // We store these in our model as lists of type item/pet/document
    // Make sure you actually initialize a list by including = new(); after
    // the get; set;.  Otherwise, when you ask the DB for a uesr object,
    // you will not see its associated items/pets/documents EVEN IF they are
    // stored in the DB.  
    // This creates the list so that it can hold the things from the DB

    // Revision:  We store these in our model as lists of type items.
    // If you chooes to use inheritance, we only require a list of 
    // the parent class for each hierarchy.  In our case, since pets and
    // documents inheirt from items, we will only store a list of
    // items.
    //Entity Framework wil see this and see that pets and documents are child
    //classes of items and when it genertes a dataabase schema for us, pets
    // and documents will in effect inheirt the foreign key relationship
    // with the uesrId for thta pet/document's owner.
    // IF you see something in the terminal about shadow
    // properties or shadow keys, check to make sure you didn't add
    // a list of child classes or something like that.  As that
    // "double applies" the relationship.
    public List<Item> items {get; set;} = new();
    // the reason we instnatiate it is because when EF creates this object for us,
    // it needs to have an empty list there.  If you don't instnatiate it, the method
    // won't fail.  You just won't get the items.  It'll always be an empty list of items.


    //public List<Pet> pets {get; set;} = new();
    //public List<Document> documents {get; set;} = new();
     // END OF CHANGES FOR EF CORE
     
    //Constructors

    //Default/No argument constructor
    public User() {}

    //This constructor takes two arguments
    public User(string _userName){
        userId = Guid.NewGuid(); //This creates a random Guid for us, without us having to worry about it
        userName = _userName;
    }
    
    
}