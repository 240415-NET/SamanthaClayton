namespace MainMenu;
using ModifySubMenu;
using GroceryItems;
using GroceryListApp;
using MainMenuSelectionHandler;

public class MainMenuClass
{
    

        //Create the main menu to prompt the user
        public static void MainMenu()

        {            
            bool keepAlive=true;
            List<GroceryItem> userGroceryList = new List<GroceryItem>();

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
                    int userMenuSelection = int.Parse(Console.ReadLine());
                    MainMenuSelectionHandlerclass.MainMenuSelectionHandler(userMenuSelection, userGroceryList);
                }

                catch (Exception e)
                {     
                    Console.WriteLine($"{e.Message} Please enter an integer value from 1 to 5.");
                    MainMenu();
                }

            }

            while (keepAlive);
        }


}