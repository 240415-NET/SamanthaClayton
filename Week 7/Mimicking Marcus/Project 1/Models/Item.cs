namespace Project1.Models;

public class Item
{
    public string? ItemID {get;set;}
    public string? ItemName {get;set;}
    public int ItemBaseValue {get;set;}
    public int QuantityOfItem {get;set;}
    public int buyLvlRequirement {get;set;}

    public Item() {}

    public Item(string ItemID, string ItemName, int ItemBaseValue, int QuantityOfItem)
    {
        this.ItemID = ItemID;
        this.ItemName = ItemName;
        this.ItemBaseValue = ItemBaseValue;
        this.QuantityOfItem = QuantityOfItem;
        buyLvlRequirement = 0;
    }

    // Didn't add his ToString() logic, Vendor/PlayerSelling, CopyFromOtherItem


}