namespace MainMenu;
using ModifySubMenu;
using GroceryItems;
using GroceryListApp;
using MainMenuSelectionHandler;

public class MainMenuClass
{
    // Create the main menu to prompt the user for a selection
    public static void MainMenu()
    {
        bool keepAlive = true;
        int userMenuSelection = 0;
        List<GroceryItem> userGroceryList = new List<GroceryItem>();
        
        // Ask the user what they'd like to do.
        // If they enter a non-integer, catch that and give them an error message.
        // Continue to ask them for a selection until keepAlive isn't true anymore
        do
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. View the grocery list");
            Console.WriteLine("2. Add to the grocery list");
            Console.WriteLine("3. Remove an item from the grocery list");
            Console.WriteLine("4. Modify an item in the grocery list");
            Console.WriteLine("5. Exit the application");

            try
            {
                userMenuSelection = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message} Please enter an integer value from 1 to 5.");
            }

            if (userMenuSelection == 5)
            {
                keepAlive = false;
                break;
            }

        // When they enter an integer, pass their selection to the selection handler
            MainMenuSelectionHandlerClass.MainMenuSelectionHandler(userMenuSelection, userGroceryList);
        }

        while (keepAlive);
    }


}