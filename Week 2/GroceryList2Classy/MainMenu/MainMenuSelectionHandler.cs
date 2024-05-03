namespace MainMenuSelectionHandler;
using ModifySubMenu;
using GroceryItems;
using GroceryListApp;
using MainMenu;
using AddSubMenu;
using RemoveSubMenu;

public class MainMenuSelectionHandlerClass
{

    // Create a method to handle the selection from the main menu
    // Originally had this as a void method with break; in each case of the switch, but
    // wanted to pass back the value of keepAlive so that the mennu would repeat if they didn't pick
    // a number between 1 to 5.  In the default, I was calling MainMenu()

    public static void MainMenuSelectionHandler(int userMenuSelection, List<GroceryItem> userGroceryList)
    {

       // bool keepAlive = false;

        switch (userMenuSelection)
        {
            // User selects 1 to view the grocery list
            case 1:
                Console.WriteLine("ITEM NAME\tQUANTITY\tBRAND/VARIETY\tPURCHASED?");
                foreach (var userGroceryItem in userGroceryList)
                {
                    Console.WriteLine(userGroceryItem);
                }
                break;

            // User selects 2 to add item(s) to the grocery list
            case 2:

                AddSubMenuClass.AddSubMenu(userGroceryList);

                break;

            case 3:  //User selects 3 to remove an item from the grocery list
                if(userGroceryList.Count() == 0)
                {
                    Console.WriteLine("Sorry, it looks like your grocery list is empty.  Plesae add to your list.");
                }
                else
                {
                    RemoveSubMenuClass.RemoveSubMenu(userGroceryList);
                }
                break;


            case 4:  //modify an item in the grocery list
                if (userGroceryList.Count()==0)
                {
                    Console.WriteLine("Sorry, it looks like your grocery list is empty.  Please add to your list.");
                }
                else
                {
                    ModifySubMenuClass.ModifySubMenu(userGroceryList);
                }
                break;


            default:
                Console.WriteLine("Invalid entry.  Please enter an integer value from 1 to 5.");
                break;

        }

    }

}


