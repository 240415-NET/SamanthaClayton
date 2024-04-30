namespace ModifySubMenuSelectionHandler;
using ModifySubMenu;
using GroceryListApp;
using GroceryItems; 
using MainMenu;
using ModifyPurchseStatus;

public class ModifySubMenuSelectionHandlerClass
{
    public static void ModifySubMenuSelectionHandler(GroceryItem selectedGroceryItemtoModify, int userModifySubMenuModSelection)
    {
        bool keepAskingUser = false;
        
        
        string selectedGroceryItemtoModifyCurrDesc = selectedGroceryItemtoModify.GetItemName();
        int selectedGroceryItemtoModifyCurrQuantity = selectedGroceryItemtoModify.GetQuantity();
        string selectedGroceryItemtoModifyCurrBrand = selectedGroceryItemtoModify.GetBrandOrVariety();
        string selectedGroceryItemtoModifyCurrPurchStatus = selectedGroceryItemtoModify.GethasBeenPurchased();

        do
        {
            switch (userModifySubMenuModSelection)
            {
                // User selects 1 to modify the item's name
                case 1:
                    
                    // Ask user to enter the new item name
                    Console.WriteLine($"What would you like to change {selectedGroceryItemtoModifyCurrDesc} to?");
                    string userGroceryItemtoModifyRevisedDesc = Console.ReadLine();

                    // Set the newly entered item name as the item name
                    selectedGroceryItemtoModify.SetItemName(userGroceryItemtoModifyRevisedDesc);

                    // Display confirmation to the user that it has changed
                    Console.WriteLine($"{selectedGroceryItemtoModifyCurrDesc} has/have been changed to {userGroceryItemtoModifyRevisedDesc}");

                    keepAskingUser = false;

                break;

                // User selects 2 to modify the quantiy of the item
                case 2:

                    // Ask user to enter a new quantity of the item
                    Console.WriteLine($"What would you like to change {selectedGroceryItemtoModifyCurrQuantity} to?");


                    // Make sure the user enters an integer
                    bool keepAskingForQuantity = false;
                    
                    do
                    {
                        try
                        {
                            selectedGroceryItemtoModify.SetQuantity(int.Parse(Console.ReadLine()));
                            keepAskingForQuantity = false;
                        }
                        catch
                        {
                            Console.WriteLine($"You're bein' silly.  How many {selectedGroceryItemtoModifyCurrDesc}()(s) do ya want?");
                            keepAskingForQuantity=true;
                        }
                    }
                    while (keepAskingForQuantity);
                    
                    // Provide confirmation to the user that the change has been made
                    Console.WriteLine($"Cool!  We updated the quantity of {selectedGroceryItemtoModifyCurrDesc}()(s) to {selectedGroceryItemtoModify.GetQuantity()}");
                    keepAskingUser = false;
                    
                    break;

                    
                    // User selects 3 to modify the brand/variety of an item
                    case 3:

                        // Ask the user what they want to change the brand/variety of the item to
                        Console.WriteLine($"What would you like to change {selectedGroceryItemtoModifyCurrBrand} to?");
                        selectedGroceryItemtoModify.SetBrandOrVariety(Console.ReadLine());

                        // Provide confirmation to the user that the change has been made
                        Console.WriteLine($"{selectedGroceryItemtoModifyCurrBrand} has been changed to {selectedGroceryItemtoModify.GetBrandOrVariety()}");
                        
                        keepAskingUser = false;

                    break;


                    // User selects 4 to change the purhcase status of an item
                    case 4:
                    
                        ModifyPurchaseStatusClass.ModifyPurchaseStatus(selectedGroceryItemtoModify);
                        keepAskingUser = false;
                    
                    break;

                    // User selects 5 to return to the main menu
                    case 5:
                        
                        keepAskingUser = false;
                    
                    break;
                                
                
                    // User enters something other than an integer from 1 to 5
                    default:
                        Console.WriteLine("Invalid Entry.  Please enter an integer from 1 to 5.");
                        keepAskingUser = true;
                    break;

            } 
        } while (keepAskingUser);

                    
    }
}