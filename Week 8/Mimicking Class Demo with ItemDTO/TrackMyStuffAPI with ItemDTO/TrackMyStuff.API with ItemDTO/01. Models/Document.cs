/*
When converting from a console application to a Web API
& using Entity Framework Core (EF Core), we copied & pasted
the models and then made some minor changes:
1. We modified the namespace
2. For EF Core, we added a no-argument constructor
    so that EF Core cancreate the models during
    database operations
3. For EF Core, we no longer want to have UserId in our
    items/documents/pets.  So we removed the UserId attribute
    from Items and then here we need to remove it from
    our constructor here in Document.  We remove
    "Guid userId" from the Document() portion &
    remove "userId" from the base() portion.
*/


// 1. MODIFY THE NAMESPACE
namespace TrackMyStuff.API.Models;

public class Document : Item
{
    public string documentType {get; set;}
    public DateTime expirationDate {get; set;}



    // 2. ADD THE NO-ARG CONTRUCTOR FOR EF CORE
    public Document() {}


    // 3. REMOVE "Guid userId" & "userId" FROM THIS CONSTRUCTOR

    public Document(string category, double originalCost, 
            DateTime purchaseDate, string description,
            string documentType, DateTime expirationDate) : 
            base(category, originalCost,purchaseDate,
            description)
    {
        this.documentType = documentType;
        this.expirationDate = expirationDate;
    }




    public override string ToString()
    {
        return $"Category: {category}\nOriginal Cost: {originalCost}\nPurchase Date: {purchaseDate}\nDescription: {description}\nDocument Type: {documentType}\nExpiration Date: {expirationDate}";
    }
}

