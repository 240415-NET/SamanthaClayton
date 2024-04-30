using System.Reflection.Metadata.Ecma335;

namespace MainMenuSelectionHandler;
using ModifySubMenu;
using GroceryItems;
using GroceryListApp;
using MainMenu;
using AddSubMenu;


public class MainMenuSelectionHandlerclass
{

       //Create a method to handle the selection from the main menu
       public static void MainMenuSelectionHandler(int userMenuSelection, List<GroceryItem> userGroceryList)
       {

            switch(userMenuSelection)
            {
                // User selects 1 to view the grocery list
                case 1: 
                    Console.WriteLine("ITEM NAME\tQUANTITY\tBRAND/VARIETY\tPURCHASED?");
                    //Console.WriteLine(String.Format("{0,-20}{1,-20}{2,-20}{3,-20}", "ITEM NAME", "QUANTITY", "BRAND/VARIETY", "PURCHASED?"));
                    foreach (var userGroceryItem in userGroceryList)
                    {
                        Console.WriteLine(userGroceryItem);
                    }

                break;
        
                // User selects 2 to add item(s) to the grocery list
                case 2:  
                    AddSubMenuClass.AddSubMenu(userGroceryList);

                break;


            case 3:  //remove an item from the grocery list
                
                RemovingSubMenu();
                void RemovingSubMenu()
                {
                    Console.WriteLine("What item would you like to remove from your grocery list?");
                    for (int i = 0; i< userGroceryList.Count; i++)
                    { 
                        Console.WriteLine($"{i+1}. {userGroceryList[i].GetItemName()}");
                    }
                    int userRemoveSelection;
                    string userRemoveSelectionDesc;
                    try
                    {
                        userRemoveSelection = int.Parse(Console.ReadLine()) - 1;
                        userRemoveSelectionDesc = userGroceryList[userRemoveSelection].GetItemName();
                        userGroceryList.RemoveAt(userRemoveSelection);
                        Console.WriteLine($"{userRemoveSelectionDesc} has/have been removed");
                    }
                    catch (Exception InvalidInput)
                    {
                        Console.WriteLine($"{InvalidInput.Message} Please enter an integer between 1 and {userGroceryList.Count}.");
                        RemovingSubMenu();
                    }
                }
            break;


            case 4:  //modify an item in the grocery list
                ModifySubMenuClass.ModifySubMenu(userGroceryList);
                break;


            case 5: //quit
            break;

            
            default:
            Console.WriteLine("Invalid entry.  Please enter an integer value from 1 to 5.");
            MainMenuClass.MainMenu();
            break;
            
            }
         
    } 
       
}


