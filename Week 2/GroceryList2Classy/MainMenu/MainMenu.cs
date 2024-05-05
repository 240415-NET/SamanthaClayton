namespace MainMenu;
using ModifySubMenu;
using GroceryItems;
using GroceryListApp;
using MainMenuSelectionHandler;
using System.Runtime.InteropServices;

public class MainMenuClass
{
    // Create the main menu to prompt the user for a selection
    public static void MainMenu()
    {
        bool keepAlive = true;
        int userMenuSelection = 0;
        List<GroceryItem> userGroceryList = new List<GroceryItem>();
        Console.Clear();
        Console.WriteLine("Welcome to the grocery list app!\n");

        
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
            Console.WriteLine("5. Exit the application\n\n\n");
            Console.Write("Selection: ");

            try
            {
                userMenuSelection = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine($"{e.Message}.\nYou entered {userMenuSelection}. Please enter an integer value from 1 to 5.\n");
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