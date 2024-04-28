namespace AddSubMenu;
using GroceryListApp;
using GroceryItems; 
using MainMenu;
using MainMenuSelectionHandler;
using AddSubMenuSelectionHandler;

public class AddSubMenuClass
{
    bool keepAdding;
    
    public static List<GroceryItem> AddSubMenu(List<GroceryItem> userGroceryList)
    {
        bool keepAdding = false;

        do
         {  
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Add an item item");
            Console.WriteLine("2. Return to main menu");
            int userSubMenuSelection = 0;
        
            try
            { 
                userSubMenuSelection = int.Parse(Console.ReadLine());
            }
            catch(Exception invalidInputType)
            {
                Console.WriteLine($"{invalidInputType.Message} Please enter an integer value of 1 or 2.");
            }

            if (userSubMenuSelection == 1)
            {
                keepAdding = true;
                AddSubMenuSelectionHandlerClass.AddSubMenuSelectionHandler(userGroceryList);
            }
            else if (userSubMenuSelection == 2)
            { 
                keepAdding = false;
            }
            else
            {
                Console.WriteLine("Invalid selection: Please enter an integer value of 1 or 2.");
            }
            
        }
        
        while (keepAdding);
        return userGroceryList;
    }
}
