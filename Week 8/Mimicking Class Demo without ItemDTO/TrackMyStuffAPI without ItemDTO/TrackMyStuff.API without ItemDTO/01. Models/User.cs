/*
When converting from a console application to a Web API
& using Entity Framework Core (EF Core), we copied & pasted
the models and then made some minor changes:
1. We modified the namespace
2. For EF Core, we used data annotations to set userId as the primary key
3. For EF Core, we added a list of items as a property/field/attribute
*/

// USING STATEMENT TO ALLOW FOR CHANGE 2
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http.Features;

// 1. MODIFY THE NAMESPACE
namespace TrackMyStuff.API.Models;

public class User
{
    // 2. USE DATA ANNOTATIONS TO SET userId AS PRIMARY KEY
    [Key]
    public Guid userId {get; set;}
    public string userName {get; set;}

    //3. ADD LIST OF ITEMS AS A PROPERTY/FIELD/ATTRIBUTE
        /*  Users can have many items/pets/documents.
            Each item can belongs to 1 user.
            So we create a list of items/pets/documents
            in our User model to reflect that Users
            can have many items/pets/documents.

            Be sure to include = new(); after the get;set;
            of this list of items. If you don't include
            the =new();, when you ask the DB for a user
            object, you will NOT see the list of that user's
            items/pets/documents even though they exist.

            Doing = new(); creates the list so that it
            can hold the things from the database.  Again,
            if you do not add this, you will always get a list
            of empty items.  (The code will NOT fail.)

            NOTE: You only need to store the list of the
            parent class.  So we don't need a list of items,
            a list of documents, and a list of pets.  We
            ony need a list of items inside of our User model.

            Entity Framework Core will see this and will
            see that pets and documents are child classes
            of the item class.  When it generates a database
            schema pets and documents will inherit the
            foreign key relationship.  If you do include
            a list of documents and a list of keys, you will
            see "shadow keys" in your database because it will
            "double apply" the relationship.
            */
    public List<Item> items {get; set;} = new();

  
    public User() {}


    // This constructor takes one argument
    public User(string _userName)
    {
            userId = Guid.NewGuid();
            userName = _userName;
    }


}
