using Project1.LogicLayer;
using Project1.Models;

namespace Project1.PresentationLayer;


public class Menus
{
    public static void StartMenu()
    {
        bool validUserInput;
        int userSelection;
        Guid userId = Guid.NewGuid();

        Console.WriteLine("What would you like to do?");
        Console.WriteLine("1. Create new profile");
        Console.WriteLine("2. Log into existing profile");
        Console.WriteLine("3. Exit");
        do
        {


            try
            {
                Console.Write("Selection: ");
                userSelection = int.Parse(Console.ReadLine() ?? "");
                validUserInput = true;

                switch(userSelection)
                {
                    case 1: // Create new profile
                    userId = UserProfileUI.CreateNewUserPrompts();
                    break;

                    case 2: // Log into existing profile
                    userId = UserProfileUI.LogInPrompts();
                    break;

                    case 3: //Exit the application
                    break;

                    default:
                        Console.WriteLine("Please enter a valid selection.");
                        validUserInput = false;
                        break;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine($"{exception.Message}\nPlease enter a valid selection.");
                validUserInput = false;
            }
        } while (!validUserInput);
        InAppMainMenu(userId);
    }

    public static void InAppMainMenu(Guid userId)
    {
        bool validUserInput;
        int userSelection;
        bool keepAlive = true;
        MealPlans userMealPlan = new MealPlans();

        do
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Generate a new meal plan");
            Console.WriteLine("2. Pull up existing meal plan");
            Console.WriteLine("3. Edit existing meal plan");
            Console.WriteLine("4. View current grocery list");
            Console.WriteLine("5. Log out");
            Console.Write("Selection: ");

            do{
            try
            {
                userSelection = int.Parse(Console.ReadLine() ?? "");
                validUserInput = true;

                switch(userSelection)
                {
                    case 1: // Create new meal plan & grocery list
                        userMealPlan = MealPlanUI.DisplayNewMealPlan(userId);
                        keepAlive = true;
                    break;

                    case 2: // Pull up existing meal plan
                        if (MealPlansLogic.CheckIfMealPlanExists(userId) == false)
                            {
                                Console.WriteLine("Oops! You don't have an existing meal plan. Please create one to view the grocery list.");
                                validUserInput = false;}
                            else
                            {
                            userMealPlan = MealPlanUI.DisplayExistingMealPlan(userId);
                            validUserInput = true;
                            }
                        keepAlive = true;
                    break;

                    case 3: //Edit existing meal plan
                        
                        if(MealPlansLogic.CheckIfMealPlanExists(userId) == false)
                        {
                                Console.WriteLine("Oops! You don't have an existing meal plan. Please create one to view the grocery list.");
                                validUserInput = false;
                        }
                        else
                        {
                            MealPlanUI.ModifyExistingMealPlan(userId);
                            validUserInput = true;
                        }
                        keepAlive = true;
                    break;

                    case 4: //View current grocery list
                        
                        if(MealPlansLogic.CheckIfMealPlanExists(userId) == false)
                        {
                                Console.WriteLine("Oops! You don't have an existing meal plan. Please create one to view the grocery list.");
                                validUserInput = false;
                        }
                        else
                        {
                            userMealPlan = MealPlanUI.DisplayExistingMealPlan(userId);
                            GroceryListUI.DisplayGroceryList(userId, userMealPlan);
                            validUserInput = true;
                        }
                        keepAlive = true;
                    break;

                    case 5: // Log out
                        keepAlive = false;
                        validUserInput = true;
                    break;

                    default:
                        Console.WriteLine("Please enter a valid selection.");
                        validUserInput = false;
                        keepAlive = true;
                        break;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine($"{exception.Message}\nPlease enter a valid selection.");
                validUserInput = false;
            }
            } while (!validUserInput);
        } while (keepAlive);
    }
    
}