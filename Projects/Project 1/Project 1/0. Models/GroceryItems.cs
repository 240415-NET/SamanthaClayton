namespace Project1.Models;

public class GroceryItems
{
    public Guid ingredientId {get; set;}
    public string itemName {get;set;} = "";

    public double quantity {get;set;} = 0;

    public string unitOfMeasure {get;set;} = "";

    public string purchased {get; set;} = "no";

    public GroceryItems(){}

    public GroceryItems(string _itemName)
    {
        ingredientId = Guid.NewGuid();
        itemName = _itemName;
        quantity = 0;
        unitOfMeasure = "";
        purchased = "no";

    }

    public GroceryItems(string _itemName, int _quantity)
    {
        ingredientId = Guid.NewGuid();
        itemName = _itemName;
        quantity = _quantity;
        unitOfMeasure = "";
        purchased = "no";
    }

    public GroceryItems (string _itemName, double _quantity, string _unitOfMeasure)
    {
        ingredientId = Guid.NewGuid();
        itemName = _itemName;
        quantity = _quantity;
        unitOfMeasure = _unitOfMeasure;
        purchased = "no";
    }

    public GroceryItems(string _itemName, double _quantity, string _unitOfMeasure, string _purchased)
    {
        ingredientId = Guid.NewGuid();
        itemName = _itemName;
        quantity = _quantity;
        unitOfMeasure = _unitOfMeasure;
        purchased = _purchased;

    }
        public GroceryItems(Guid _ingredientId, string _itemName, double _quantity, string _unitOfMeasure, string _purchased)
    {
        ingredientId = _ingredientId;
        itemName = _itemName;
        quantity = _quantity;
        unitOfMeasure = _unitOfMeasure;
        purchased = _purchased;

    }


}