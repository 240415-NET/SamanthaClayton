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
                ModifySubMenu();
                void ModifySubMenu()
                {
                    //prompt user to pick which item they want to modify
                    Console.WriteLine("What item would you like to modify in your grocery list?");
                    for (int i = 0; i< userGroceryList.Count; i++)
                    { 
                        Console.WriteLine($"{i+1}. {userGroceryList[i].GetItemName()}");
                    }
                    
                    int userModifySelection = 0;
                    try
                    {
                        userModifySelection = int.Parse(Console.ReadLine()) - 1;
                        GroceryItem userGroceryListItem = userGroceryList[userModifySelection];
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Provide an integer correspondng to the item you want to modify");
                        ModifySubMenu();
                    }
                    string userModifySelectionDesc = userGroceryList[userModifySelection].GetItemName();

                    //ask user what they want to modify & make sure they enter a valid input
                    bool keepBuggingEm = false;
                    int userModifySubMenuSelection = 1;
                    do
                    {
                        Console.WriteLine($"What would you like to change about {userModifySelectionDesc}?");
                        Console.WriteLine("1. Name");
                        Console.WriteLine("2. Quantity");
                        Console.WriteLine("3. Brand/Variety");
                        Console.WriteLine("4. Purchased");
                        Console.WriteLine("5. Delete the whole thing RIGHT NOW!");
                        Console.WriteLine("6. Return to main menu");

                        try
                        {
                            userModifySubMenuSelection = int.Parse(Console.ReadLine());
                            keepBuggingEm = false;
                        }
                        catch(Exception lilException)
                        {
                            Console.WriteLine($"{lilException.Message} PLEASE enter an integer from 1 to 6!");
                            keepBuggingEm = true;
                        }
                    }
                    while (keepBuggingEm);

                    //handle user input
                    string userModifySubMenuSelectionDesc = "";
                    switch (userModifySubMenuSelection)
                    {
                            case 1: //user modifies item name
                                userModifySubMenuSelectionDesc = userGroceryList[userModifySelection].GetItemName();
                                Console.WriteLine($"What would you like to change {userModifySelectionDesc} to?");
                                string userRevisedSelectionDesc = Console.ReadLine();
                                userGroceryList[userModifySelection].SetItemName(userRevisedSelectionDesc);
                                Console.WriteLine($"{userModifySelectionDesc} has/have been changed to {userRevisedSelectionDesc}");
                            break;

                            case 2: // user modifies quantity of an item
                                Console.WriteLine($"What would you like to change {userGroceryList[userModifySelection].GetQuantity()} to?");
                                bool keepAskingForQuantity = false;
                                do
                                {
                                    try
                                    {
                                    userGroceryList[userModifySelection].SetQuantity(int.Parse(Console.ReadLine()));
                                    keepAskingForQuantity = false;
                                    }
                                    catch
                                    {
                                        Console.WriteLine($"You're bein' silly.  How many {userGroceryList[userModifySelection].GetItemName()}(s) do ya want?");
                                        keepAskingForQuantity=true;
                                    }
                                }
                                while (keepAskingForQuantity);
                                Console.WriteLine($"Cool!  We updated the quantity of {userGroceryList[userModifySelection].GetItemName()}(s) to " +
                                    $"{userGroceryList[userModifySelection].GetQuantity()}");
                            break;

                        case 3: //user modifies brand/variety of an item
                                string userModifyItemBrandOrVariety= userGroceryList[userModifySelection].GetBrandOrVariety();
                                Console.WriteLine($"What would you like to change {userModifyItemBrandOrVariety} to?");
                                string userRevisedItemBrandOrVariety = Console.ReadLine();
                                userGroceryList[userModifySelection].SetBrandOrVariety(userRevisedItemBrandOrVariety);
                                Console.WriteLine($"{userModifyItemBrandOrVariety} has/have been changed to {userRevisedItemBrandOrVariety}");

                        //   userModifySubMenuSelectionDesc = userGroceryList[userModifySelection].GetBrandOrVariety();
                        break;

                        case 4: //user marks an item as purchased or nah
                            GroceryItem userSelectedGroceryItem = userGroceryList[userModifySelection];
                            ModifySubMenuClass.ModifyPurchasedMethod(userSelectedGroceryItem);
                        break;

                        case 5: //user removes an item entirely instead of going though the main menu's remove option
                            GroceryItem ItemToDelete = userGroceryList[userModifySelection];
                            string ItemToDeletesName = ItemToDelete.GetItemName();
                            Console.WriteLine($"Okay, chill.  You sure you wanna delete {ItemToDeletesName}????" +
                                $"  Idk how to program undo yet, so no take backs (yes/no)");
                            bool keepOnGoing = false;
                            do
                                {
                                    string userInputYesOrNo = Console.ReadLine();
                                    if (userInputYesOrNo.ToLower() == "yes")
                                    {
                                        
                                        userGroceryList.RemoveAt(userModifySelection);
                                        Console.WriteLine($"{ItemToDeletesName} is gone... FOREVER!");
                                        keepOnGoing = false;
                                    }
                                    else if (userInputYesOrNo.ToLower() =="no")
                                    {
                                        Console.WriteLine($"Okay, {ItemToDeletesName} hasn't been deleted");
                                        keepOnGoing = false;                
                                    }
                                    else
                                    {
                                        Console.WriteLine("Type yes or no - c'mon man!");
                                        keepOnGoing = true;
                                    }
                                }
                                while (keepOnGoing);  
                            break;

                        case 6:
                        MainMenuClass.MainMenu();
                        break;
                            
            
                        default:  //user is so dum rn, like really really dum

                                Console.WriteLine("Invalid Entry.  Please enter an integer from 1 to 5.");
                                ModifySubMenu();
                        break;

                    }

                    
                    }
                
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


