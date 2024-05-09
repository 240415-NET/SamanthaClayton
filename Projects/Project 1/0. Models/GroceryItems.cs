namespace Project1.Models;

public class GroceryItems
{
    private double v1;
    private string v2;
    private string v3;

    public string itemName {get;set;} = "";

    public double quantity {get;set;} = 1;

    public string unitOfMeasure {get;set;} = "";

    public string purchased {get; set;} = "no";

    public GroceryItems(){}

    public GroceryItems(string _itemName)
    {
        itemName = _itemName;
        quantity = 1;
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

    public GroceryItems (string _itemName, int _quantity, string _unitOfMeasure)
    {
        itemName = _itemName;
        quantity = _quantity;
        unitOfMeasure = _unitOfMeasure;
        purchased = "no";
    }

    public GroceryItems(string _itemName, int _quantity, string _unitOfMeasure, string _purchased)
    {
        itemName = _itemName;
        quantity = _quantity;
        unitOfMeasure = _unitOfMeasure;
        purchased = _purchased;

    }

    public GroceryItems(string _itemName, double v1, string v2, string v3) : this(_itemName)
    {
        this.v1 = v1;
        this.v2 = v2;
        this.v3 = v3;
    }
}