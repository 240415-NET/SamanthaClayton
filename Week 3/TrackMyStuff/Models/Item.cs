namespace TrackMyStuff.Models;

public class Item
{
    public Guid userId {get; set;}
    public Guid itemId {get; private set;}
    public string category {get; set;}
    public double originalCost  {get; set;}
    public DateTime purchaseDate {get; set;}
    public string description {get; set;}


    public Item (){}


    public Item  (Guid _userId, Guid _itemId, string _category,
                double _originalCost, DateTime _purchaseDate,
                string _description)
    {
        userId = _userId;
        itemId = Guid.NewGuid();
        category = _category;
        originalCost = _originalCost;
        purchaseDate = _purchaseDate;
        description = _description;
    }

}