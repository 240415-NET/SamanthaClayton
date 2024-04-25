using System.IO.Pipes;
using System.Runtime.CompilerServices;

namespace GroceryItems;


    public class GroceryItem
    {

        // Fields that make up the GroceryItem class
        private string ItemName = "Default item name";
        private int Quantity = 1;
        private string BrandOrVariety = "any";
        private bool hasBeenPurchased = false;


        // Generic constructor for creating objects of the GroceryItem class
        public GroceryItem(){}

        // Constructor that allows parameters to be passed in order to create an object of the GroceryItem class

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


        // These methods will describe how we set and get values for each of the fields
        // that make up the objects of GroceryItem class
        public string GetItemName(){
            return ItemName;
        }

        public void SetItemName(string Name){
            ItemName = Name;
        }

        public int GetQuantity(){
            return Quantity;
        }

        public void SetQuantity(int Number){
            Quantity = Number;
        }

        public string GetBrandOrVariety(){
            return BrandOrVariety;
        }

        public void SetBrandOrVariety(string VarietyOrBrand){
            BrandOrVariety = VarietyOrBrand;
        }

        public string GethasBeenPurchased(){
            if (hasBeenPurchased==true)
            {return "yes";}
            else {return "no";}
        }

        public void SethasBeenPurchased(string Purchased){
            if (Purchased == "yes")
            {hasBeenPurchased=true;
            }
            else {hasBeenPurchased = false;}
        }

         // Override the ToString

        // public override string ToString()
        // {
        //    return $"{ItemName} ---- {Quantity} ---- {BrandOrVariety} ---- {hasBeenPurchased}";
        // }
    

    //Practicing adding and displaying a list that contains objects of the GroceryItem class
    // public static void Main(string[] args)
    // {
    //     List<GroceryItem> MyGroceryList = new List<GroceryItem>();
    //     GroceryItem item1 = new GroceryItem("apples", 2, "gala", "no");
    //     GroceryItem item2 = new GroceryItem("bananas", 3, "regular", "no");
    //     MyGroceryList.Add(item1);
    //     MyGroceryList.Add(item2);

    //     foreach (var item in MyGroceryList)
    //     {
    //         Console.WriteLine($"{item.ItemName} -- {item.Quantity} -- {item.BrandOrVariety} -- {item.hasBeenPurchased}");
    //     }

    //     item1.SetBrandOrVariety("red delicious");

    //     foreach (var item in MyGroceryList)
    //     {
    //         Console.WriteLine($"{item.ItemName} -- {item.Quantity} -- {item.BrandOrVariety} -- {item.hasBeenPurchased}");
        
    // }
    // Console.WriteLine(item1.GetItemName());
    // item2.SethasBeenPurchased("yes");
    // Console.WriteLine(item2.GethasBeenPurchased());
    // Console.WriteLine(item2.hasBeenPurchased);

    
    
    // }
    }

    

