namespace Project1.Models;

public class GroceryItems
{
    public string itemName {get;set;} = "";

    public double quantity {get;set;} = 0;

    public string unitOfMeasure {get;set;} = "";

    public string purchased {get; set;} = "no";

    public GroceryItems(){}

    public GroceryItems(string _itemName)
    {
        itemName = _itemName;
        quantity = 0;
        unitOfMeasure = "";
        purchased = "no";

    }

    public GroceryItems(string _itemName, int _quantity)
    {
        itemName = _itemName;
        quantity = _quantity;
        unitOfMeasure = "";
        purchased = "no";
    }

    public GroceryItems (string _itemName, double _quantity, string _unitOfMeasure)
    {
        itemName = _itemName;
        quantity = _quantity;
        unitOfMeasure = _unitOfMeasure;
        purchased = "no";
    }

    public GroceryItems(string _itemName, double _quantity, string _unitOfMeasure, string _purchased)
    {
        itemName = _itemName;
        quantity = _quantity;
        unitOfMeasure = _unitOfMeasure;
        purchased = _purchased;

    }

}