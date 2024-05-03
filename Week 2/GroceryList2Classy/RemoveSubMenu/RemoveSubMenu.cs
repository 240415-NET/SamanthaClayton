namespace RemoveSubMenu;
using ModifySubMenu;
using GroceryListApp;
using GroceryItems;
using MainMenu;
using ModifySubMenuSelectionHandler;

public class RemoveSubMenuClass
{

    public static List<GroceryItem> RemoveSubMenu(List<GroceryItem> userGroceryList)

    {
        int userRemoveSelection;
        string userRemoveSelectionDesc;
        bool keepAlive = true;

        do
        {
            Console.WriteLine("What item would you like to remove from your grocery list?");
            for (int i = 0; i < userGroceryList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {userGroceryList[i].GetItemName()}");
                //Console.WriteLine("i'm in the removesubmenu FOR LOOP");
            }
            try
            {
                userRemoveSelection = int.Parse(Console.ReadLine()) - 1;
                userRemoveSelectionDesc = userGroceryList[userRemoveSelection].GetItemName();
                userGroceryList.RemoveAt(userRemoveSelection);
                Console.WriteLine($"{userRemoveSelectionDesc} has/have been removed");
                keepAlive=false;
            }

            catch (Exception InvalidInput)
            {
                Console.WriteLine($"{InvalidInput.Message} Please enter an integer between 1 and {userGroceryList.Count}.");
                keepAlive=true;
            }

        }
        while (keepAlive);

        return userGroceryList;
    }
}