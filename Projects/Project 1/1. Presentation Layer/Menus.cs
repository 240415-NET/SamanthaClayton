using Project1.Models;
using Project1.LogicLayer;

namespace Project1.PresentationLayer;


public class Menus
{
    public static void StartMenu()
    {
        bool validUserInput;
        int userSelection;

        do
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Create new profile");
            Console.WriteLine("2. Log into existing profile");
            Console.WriteLine("3. Exit");

            try
            {
                userSelection = int.Parse(Console.ReadLine() ?? "");
                validUserInput = true;

                switch(userSelection)
                {
                    case 1: // Create new profile
                    UserProfileUI.CreateNewUserPrompts();
                    break;

                    case 2: // Log into existing profile
                    UserProfileUI.LogInPrompts();
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
        InAppMainMenu(); //Is this where I'd call this or the Progrma.cs or somewhere else?
    }

    public static void InAppMainMenu()
    {
        bool validUserInput;
        int userSelection;

        do
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Generate a new meal plan");
            Console.WriteLine("2. View &/or modify an existing meal plan");
            Console.WriteLine("3. View &/or modify an existing grocery list");
            // Console.WriteLine("Add new recipe");
            Console.WriteLine("4. Log out");

            try
            {
                userSelection = int.Parse(Console.ReadLine() ?? "");
                validUserInput = true;

                switch(userSelection)
                {
                    case 1: // Create new meal plan & grocery list
                    MealPlanUI.DisplayNewMealPlan();
                    break;

                    case 2: // View or modify existing meal plan   
                    break;

                    case 3: // View or modify existing grocery list
                    break;

                    case 4: // Log out
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
    }


    
}