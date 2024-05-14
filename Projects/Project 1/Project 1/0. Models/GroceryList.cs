namespace Project1.Models;

public class GroceryLists
{
    public List<GroceryItems>? groceryList {get;set;}
    
    public GroceryLists(){}

    public GroceryLists (List<GroceryItems> _groceryList)
    {
        groceryList = _groceryList;
    }

}