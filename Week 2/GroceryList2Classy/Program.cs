namespace GroceryList2Classy;
using GroceryItems;
using System.ComponentModel;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;


class Program
{
    static void Main(string[] args)
    {
        List<GroceryItem> userGroceryList = new List<GroceryItem>();
        bool keepAlive=true;
        Menu();

        void Menu ()
        {
            do{
        Console.WriteLine("What would you like to do?");
        Console.WriteLine("1. View the grocery list");
        Console.WriteLine("2. Add to the grocery list");
        Console.WriteLine("3. Remove an item from the grocery list");
        Console.WriteLine("4. Modify an item in the grocery list");
        Console.WriteLine("5. Exit the application");

        try
        {int userMenuSelection = int.Parse(Console.ReadLine());
        SelectionHandler(userMenuSelection);
        }
        catch (Exception e)
        {Console.WriteLine($"{e.Message} Please enter an integer value from 1 to 5.");
        Menu();}
        }
        while (keepAlive);
        }

       //create a method to handle the selection from the main menu
       void SelectionHandler(int userMenuSelection){

        switch(userMenuSelection)
            {
            case 1:  //view the grocery list 
               
                Console.WriteLine("Here is your grocery list:");
                foreach (var userGroceryItem in userGroceryList)
                {Console.WriteLine($"{userGroceryItem.GetItemName()} || {userGroceryItem.GetBrandOrVariety()} || {userGroceryItem.GetQuantity()} || {userGroceryItem.GethasBeenPurchased()}");
                }
               break;


            case 2:  //add to the grocery list 
                bool keepAdding = true;
                do
                {Console.WriteLine("Enter the name of the item you'd like to add:");
                GroceryItem newuserGroceryItem = new GroceryItem();
                newuserGroceryItem.SetItemName(Console.ReadLine());
                Console.WriteLine("Enter the quantity of the item you're adding");
                newuserGroceryItem.SetQuantity(int.Parse(Console.ReadLine()));
                Console.WriteLine("Enter the brand or variety of the itemg");
                newuserGroceryItem.SetBrandOrVariety(Console.ReadLine());

                userGroceryList.Add(newuserGroceryItem);
                AddingSubMenu();

                void AddingSubMenu(){
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. Add another item");
                Console.WriteLine("2. Return to main menu");
                int userSubMenuSelection;

                try{userSubMenuSelection = int.Parse(Console.ReadLine());
                 if (userSubMenuSelection == 1)
                    {
                        keepAdding = true;
                    }
                    else if (userSubMenuSelection == 2)
                     { 
                        keepAdding = false;
                     }
                     else
                     {Console.WriteLine("Invalid selection: Please enter an integer value of 1 or 2.");
                     AddingSubMenu();
                     }   
                     }
                catch(Exception invalidInputType)
                {Console.WriteLine($"{invalidInputType.Message} Please enter an integer value of 1 or 2.");}
               
                
        

                }
            
            }
            while (keepAdding);
                break;


            case 3:  //remove an item from the grocery list
                
                RemovingSubMenu();
                void RemovingSubMenu(){
                    Console.WriteLine("What item would you like to remove from your grocery list?");
                    for (int i = 0; i< userGroceryList.Count; i++)
                    { 
                    Console.WriteLine($"{i+1}. {userGroceryList[i].GetItemName()}");
                    }
                int userRemoveSelection;
                string userRemoveSelectionDesc;
                try{
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
            Console.WriteLine("What item would you like to modify in your grocery list?");
                for (int i = 0; i< userGroceryList.Count; i++)
                { 
                    Console.WriteLine($"{i+1}. {userGroceryList[i].GetItemName()}");
                 
                }
                int userModifySelection = int.Parse(Console.ReadLine()) - 1;
                string userModifySelectionDesc = userGroceryList[userModifySelection].GetItemName();


                Console.WriteLine($"What would you like to change {userModifySelectionDesc} to?");
                string userRevisedSelectionDesc = Console.ReadLine();
                userGroceryList[userModifySelection].SetItemName(userRevisedSelectionDesc);

                Console.WriteLine($"{userModifySelectionDesc} has/have been changed to {userRevisedSelectionDesc}");
                break;


            case 5: //quit
                keepAlive=false;
                break;

            
            default:
            Console.WriteLine("Invalid entry.  Please enter an integer value from 1 to 5.");
            Menu();
            break;
            
            }
            
       }
     
    }
}
