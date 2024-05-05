namespace AddSubMenuSelectionHandler;
using GroceryListApp;
using GroceryItems; 
using MainMenu;
using MainMenuSelectionHandler;

public class AddSubMenuSelectionHandlerClass
{

    public static List<GroceryItem> AddSubMenuSelectionHandler(List<GroceryItem> userGroceryList)
    {

            GroceryItem newuserGroceryItem = new GroceryItem();
            Console.Clear();


            // Have the user enter the item name and set it
                Console.Write("Enter the name of the item you'd like to add: ");
                newuserGroceryItem.SetItemName(Console.ReadLine());


            // Have the user enter the quantiy of the item, check to make sure it's an
            // integer.  If it is, then set it.  If it's not an integer, keep
            // prompting them until they enter an integer
                Console.Write("Enter the quantity of the item you're adding: ");

                bool keepAsking = false;

                    do
                    {
                        try
                        {
                            newuserGroceryItem.SetQuantity(int.Parse(Console.ReadLine()));
                            keepAsking = false;
                        }
                        catch
                        {
                            Console.WriteLine($"You're bein' silly.  How many {newuserGroceryItem.GetItemName()}(s) do ya want?");
                            keepAsking=true;
                        }
                    }
                    while (keepAsking);


            // Have the user enter the brand or variety and set it
                Console.Write("Enter the brand or variety of the item: ");
                newuserGroceryItem.SetBrandOrVariety(Console.ReadLine());
            
            
            // Add the new item to the list
            userGroceryList.Add(newuserGroceryItem);
            

            return userGroceryList;
    }
}