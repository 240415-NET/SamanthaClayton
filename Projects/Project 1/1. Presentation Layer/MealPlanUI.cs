using System.Diagnostics;
using Project1.LogicLayer;
using Project1.Models;

namespace Project1.PresentationLayer;

public class MealPlanUI
{

    public static void DisplayNewMealPlan()
    {
        bool keepAlive = true;
        do
        {
        Console.Clear();
        MealPlans newUserMealPlan = MealPlansLogic.GenerateNewMealPlan();
        Console.WriteLine("Here's your meal plan!");

        for (int i = 0; i < newUserMealPlan.mealList.Count(); i++)
        {
            Console.WriteLine($"Day {i+1}: {newUserMealPlan.mealList[i]}");

        }

        bool validUserInput;
        int userSelection;

        do
        {
            Console.WriteLine("\n\n\n\n\nWhat would you like to do?");
            Console.WriteLine("1. Generate a new meal plan");
            Console.WriteLine("2. Save this meal plan & view the grocery list");
            Console.WriteLine("3. Log out");


            try
            {
                userSelection = int.Parse(Console.ReadLine() ?? "");
                validUserInput = true;
                keepAlive=true;

                switch(userSelection)
                {
                    case 1: // Create new meal plan & grocery list
                    break;

                    case 2: // Save meal plan & view grocery list
                    keepAlive = false;
                    break;

                    case 3: //Exit the app
                    keepAlive = false;
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
                keepAlive=true;
            }

        } while (!validUserInput);
    } while (keepAlive);
    }
}