using System.IO.Pipes;
using System.Runtime.CompilerServices;

namespace GroceryItems;
using GroceryListApp;
using MainMenu;
using ModifySubMenu;


    public class GroceryItem
    {
        // These are the fields that make up any objects of the GroceryItem class
            private string ItemName = "Default item name";
            private int Quantity = 1;
            private string BrandOrVariety = "any";
            private string hasBeenPurchased = "no";


        // Constructors for creating objects of the GroceryItem class

            // No argument (no-args) constructor that allows you to create
            // an object of GroceryItem class to be created without needing
            // to pass any parameters
            public GroceryItem(){}

            // Constructor that allows you to create an object of GroceryItem class
            // to be created by passing only name & number so you don't need to provide
            // the item brand/variety or whether it was purchased
            public GroceryItem(string Name, int Number)
            {
                ItemName = Name;
                Quantity = Number;
            }
            
            // Constructor that allows you to create an object
            // of GroceryItem class to be created by passing name, number, &
            // variety or brand.  You don't need to provide whether the item
            // has been purchased or not.

            public GroceryItem(string Name, int Number, string VarietyOrBrand)
            {
                ItemName = Name;
                Quantity = Number;
                BrandOrVariety = VarietyOrBrand;
            }
            // Constructor tht allows you to create an object of
            // GroceryItem class to be created by passing all 4 of the parameters.

            public GroceryItem(string Name, int Number, string VarietyOrBrand, string Purchased)
            {
                ItemName = Name;
                Quantity = Number;
                BrandOrVariety = VarietyOrBrand;
                hasBeenPurchased = Purchased;
            }


    // Getter & Setter Methods
        // These methods describe how we set and get values for each of the fields
        // that make up the objects of GroceryItem class
            public string GetItemName()
            {
                return ItemName;
            }

            public void SetItemName(string Name)
            {
                ItemName = Name;
            }

            public int GetQuantity()
            {
                return Quantity;
            }

            public void SetQuantity(int Number)
            {
                Quantity = Number;
            }

            public string GetBrandOrVariety()
            {
                return BrandOrVariety;
            }

            public void SetBrandOrVariety(string VarietyOrBrand)
            {
                BrandOrVariety = VarietyOrBrand;
            }

            public string GethasBeenPurchased()
            {
                return hasBeenPurchased;
            }

            public void SethasBeenPurchased(string Purchased)
            {
                hasBeenPurchased = Purchased;
            }


    // This overrides the GroceryClass item's ToString() method.
    // This sets what will display when you try to print an object of the
    // GroceryItem class to the console
        public override string ToString()
        {
            return $"{ItemName}\t\t{Quantity}\t\t{BrandOrVariety}\t\t{hasBeenPurchased}";
            //return String.Format("{0,-20}{1,-20}{2,-20}{3,-20}",ItemName,Quantity,BrandOrVariety,hasBeenPurchased);

        }

    }

