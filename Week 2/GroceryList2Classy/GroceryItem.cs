using System.IO.Pipes;
using System.Runtime.CompilerServices;

namespace GroceryItems;
using GroceryListApp;
using MainMenu;
using ModifySubMenu;


    public class GroceryItem
    {

        // Fields that make up the GroceryItem class
        private string ItemName = "Default item name";
        private int Quantity = 1;
        private string BrandOrVariety = "any";
        private string hasBeenPurchased = "no";


        // Generic constructor for creating objects of the GroceryItem class
        public GroceryItem(){}

        public GroceryItem(string Name, int Number, string VarietyOrBrand)
        {
            ItemName = Name;
            Quantity = Number;
            BrandOrVariety = VarietyOrBrand;
        }
        // Constructor that allows parameters to be passed in order to create an object of the GroceryItem class

        public GroceryItem(string Name, int Number, string VarietyOrBrand, string Purchased)
        {
            ItemName = Name;
            Quantity = Number;
            BrandOrVariety = VarietyOrBrand;
            hasBeenPurchased = "yes";
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
            return hasBeenPurchased;
            
        }

        public void SethasBeenPurchased(string Purchased){
            hasBeenPurchased = Purchased;
        }

    public override string ToString()
    {
       // return $"{ItemName}          {Quantity}          {BrandOrVariety}          {hasBeenPurchased}";
        return String.Format("{0,-20}{1,-20}{2,-20}{3,-20}",ItemName,Quantity,BrandOrVariety,hasBeenPurchased);
    }

    }

