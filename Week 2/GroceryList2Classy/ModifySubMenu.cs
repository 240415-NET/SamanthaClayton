namespace ModifySubMenu;
using GroceryListApp;
using GroceryItems; 
using MainMenu;
using ModifySubMenuSelectionHandler;


public class ModifySubMenuClass
{
    public static void ModifySubMenu(List<GroceryItem> userGroceryList)
    {
        
        // Ask user to pick which item they want to modify & display grocery items
            Console.WriteLine("Which item would you like to modify?");
            
            for (int i = 0; i< userGroceryList.Count; i++)
            { 
                Console.WriteLine($"{i+1}. {userGroceryList[i].GetItemName()}");
            }
            
            int userModifySubMenuItemSelection = 0;
            GroceryItem selectedGroceryItemtoModify;
            bool keepPrompting = false;
            do
            {
                try
                {
                    userModifySubMenuItemSelection = int.Parse(Console.ReadLine()) - 1;
                    keepPrompting = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Provide an integer correspondng to the item you want to modify");
                    keepPrompting = true;
                }
            selectedGroceryItemtoModify = userGroceryList[userModifySubMenuItemSelection];
            }
            while (keepPrompting);
            
            string userModifySelectionDesc = selectedGroceryItemtoModify.GetItemName();

            // Ask user what they want to modify about the item & make sure they enter a valid input
            
            bool keepBuggingEm = false;
            int userModifySubMenuModSelection = 1;
                
            do
            {
                Console.WriteLine($"What would you like to change about {userModifySelectionDesc}?");
                Console.WriteLine("1. Name");
                Console.WriteLine("2. Quantity");
                Console.WriteLine("3. Brand/Variety");
                Console.WriteLine("4. Purchased");
                Console.WriteLine("5. Return to main menu");

                try
                {
                    userModifySubMenuModSelection = int.Parse(Console.ReadLine());
                    keepBuggingEm = false;
                }
                catch(Exception lilException)
                {
                    Console.WriteLine($"{lilException.Message} PLEASE enter an integer from 1 to 6!");
                    keepBuggingEm = true;
                }
            
            ModifySubMenuSelectionHandlerClass.ModifySubMenuSelectionHandler(selectedGroceryItemtoModify, userModifySubMenuModSelection);
            }
            while (keepBuggingEm);
            

    }
}