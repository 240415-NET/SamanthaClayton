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
            Console.Clear();

            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Add an item item");
            Console.WriteLine("2. Return to main menu\n");
            int userSubMenuSelection = 0;
            Console.Write("Selection: ");
        
            try
            { 
                userSubMenuSelection = int.Parse(Console.ReadLine());
            }
            catch(Exception invalidInputType)
            {
                //Console.Clear();
                Console.WriteLine($"{invalidInputType.Message} You entered {userSubMenuSelection}. Please enter an integer value of 1 or 2.");
            }

            if (userSubMenuSelection == 1)
            {
                keepAdding = true;
                AddSubMenuSelectionHandlerClass.AddSubMenuSelectionHandler(userGroceryList);
                Console.WriteLine($"Your items were added!");

            }
            else if (userSubMenuSelection == 2)
            { 
                keepAdding = false;
            }
            else
            {
                //Console.Clear();
                Console.WriteLine($"You entered {userSubMenuSelection}. Pease enter an integer value of 1 or 2.");
            }
            
        }
        
        while (keepAdding);
        return userGroceryList;
    }
}
