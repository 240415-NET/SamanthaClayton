namespace ModifySubMenu;
using GroceryListApp;
using GroceryItems;
using MainMenu;
using ModifySubMenuSelectionHandler;
using System.Runtime.InteropServices;

public class ModifySubMenuClass
{
    public static void ModifySubMenu(List<GroceryItem> userGroceryList)
    {
        int userModifySubMenuItemSelection = 0;
        GroceryItem selectedGroceryItemtoModify = new GroceryItem();
        bool keepPrompting = true;
        bool keepGoing = true;
        do
        {
            do
            {

                // Ask user to pick which item they want to modify & display grocery items
                Console.WriteLine("Which item would you like to modify?");

                for (int i = 0; i < userGroceryList.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {userGroceryList[i].GetItemName()}");
                }


                try
                {
                    userModifySubMenuItemSelection = int.Parse(Console.ReadLine()) - 1;
                    selectedGroceryItemtoModify = userGroceryList[userModifySubMenuItemSelection];
                    keepPrompting = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Provide an integer correspondng to the item you want to modify");
                    keepPrompting = true;
                }
            }
            while (keepPrompting);

            string userModifySelectionDesc = selectedGroceryItemtoModify.GetItemName();

            // Ask user what they want to modify about the item & make sure they enter a valid input

            bool keepBuggingEm = true;
            int userModifySubMenuModSelection = 0;

            do
            {
                Console.Clear();
                userModifySelectionDesc = selectedGroceryItemtoModify.GetItemName();
                Console.WriteLine($"What would you like to change about {userModifySelectionDesc}?");
                Console.WriteLine("1. Name");
                Console.WriteLine("2. Quantity");
                Console.WriteLine("3. Brand/Variety");
                Console.WriteLine("4. Purchased");
                Console.WriteLine("5. Pick a different item to modify");
                Console.WriteLine("6. Return to main menu");


                try
                {
                    userModifySubMenuModSelection = int.Parse(Console.ReadLine());
                }
                catch (Exception lilException)
                {
                    Console.WriteLine($"{lilException.Message} PLEASE enter an integer from 1 to 6!");
                }

                if (userModifySubMenuModSelection == 5)
                {
                    keepBuggingEm = false;
                    break;
                }
                else if (userModifySubMenuModSelection == 6)
                {
                    keepBuggingEm = false;
                    keepGoing = false;
                    break;
                }


                ModifySubMenuSelectionHandlerClass.ModifySubMenuSelectionHandler(selectedGroceryItemtoModify, userModifySubMenuModSelection);
            }
            while (keepBuggingEm);
        } while (keepGoing);


    }
}