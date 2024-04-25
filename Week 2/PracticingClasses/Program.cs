namespace PracticingClasses;

class Program
{
    public class GroceryItem
    {
        private string ItemName = "Default item name";
        private int Quantity = 1;
        private string BrandOrVariety = "any";
        private bool hasBeenPurchased = false;


        public GroceryItem(){}

        public GroceryItem(string Name, int Number, string VarietyOrBrand, string Purchased)
        {
            ItemName = Name;
            Quantity = Number;
            BrandOrVariety = VarietyOrBrand;
            if (Purchased == "yes")
            {
                hasBeenPurchased = true;
            }
            else
            {
                hasBeenPurchased = false;
            }

        }
    
    public static void Main(string[] args)
    {
        List<GroceryItem> MyGroceryList = new List<GroceryItem>();
        GroceryItem item1 = new GroceryItem("apples", 2, "gala", "no");
        GroceryItem item2 = new GroceryItem("bananas", 3, "regular", "no");
        MyGroceryList.Add(item1);
        MyGroceryList.Add(item2);

        foreach (var item in MyGroceryList)
        {
            Console.WriteLine($"{item.ItemName} -- {item.Quantity} -- {item.BrandOrVariety} -- {item.hasBeenPurchased}");
        }
    }
    }

    


}
