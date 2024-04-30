namespace ModifyPurchseStatus;
using GroceryListApp;
using GroceryItems; 
using MainMenu;


public class ModifyPurchaseStatusClass
{
    public static void ModifyPurchaseStatus(GroceryItem selectedGroceryItemtoModify)
    {
        Console.WriteLine($"Did you purchase {selectedGroceryItemtoModify.GetItemName()}? (yes/no)");
        bool keepOnGoing = false;
        do
        {
            string userInputYesOrNo = Console.ReadLine();
            if (userInputYesOrNo.ToLower() == "yes")
            {
                selectedGroceryItemtoModify.SethasBeenPurchased("yes");
                Console.WriteLine("Congrats on getting that done!");
                keepOnGoing = false;
            }
            else if (userInputYesOrNo.ToLower() =="no")
            {
                selectedGroceryItemtoModify.SethasBeenPurchased("no");
                Console.WriteLine($"You didn't purchase {selectedGroceryItemtoModify.GetItemName()} - got it!");
                keepOnGoing = false;                
            }
            else
            {
                Console.WriteLine("Type yes or no - c'mon man!");
                keepOnGoing = true;
            }
       }
       while (keepOnGoing);         
    }
}