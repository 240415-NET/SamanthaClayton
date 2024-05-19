using Project1.LogicLayer;
using Project1.Models;

namespace Project1.PresentationLayer;

public class MealPlanUI
{

    public static MealPlans DisplayNewMealPlan(Guid userId)
    {
        bool generateAgain = true;
        bool validUserInput = true;
        MealPlans newUserMealPlan = new MealPlans();

        do
        {Console.Clear();
        newUserMealPlan = MealsLogic.GetStoredMeals(5);
        Console.WriteLine("Here's your meal plan!");

        for (int i = 0; i < newUserMealPlan.mealNames.Count(); i++)
        {
            Console.WriteLine($"Day {i + 1}: {newUserMealPlan.mealNames[i]}");
        }
        Console.WriteLine("\n\n");

        Console.WriteLine("Enter 1 to save your meal plan or 2 to generate a new one.");
        Console.Write("Selection: ");

        do {
        try
        {
            int userSelection = int.Parse(Console.ReadLine() ?? "");
            switch(userSelection)
            {
                case 1:
                generateAgain = false;
                validUserInput = true;
                MealPlansLogic.SaveMealPlan(userId, newUserMealPlan);

                Console.Clear();
                break;
                
                case 2:
                generateAgain = true;
                validUserInput = true;
                Console.Clear();
                break;

                default:
                Console.WriteLine("Please enter a valid selection");
                validUserInput = false;
                break;
            }
        }
        catch
        {
           Console.WriteLine("Please enter a valid selection");
            validUserInput = false;
        }
        }while(!validUserInput);
        } while (!validUserInput || generateAgain);
        return newUserMealPlan;
    }

    public static MealPlans DisplayExistingMealPlan(Guid userId)
    {
        //Console.Clear();
        MealPlans existingUserMealPlan = MealPlansLogic.GetMealPlan(userId);
        Console.WriteLine("Here's your meal plan!");

        for (int i = 0; i < existingUserMealPlan.mealNames.Count(); i++)
        {
            Console.WriteLine($"Day {i + 1}: {existingUserMealPlan.mealNames[i]}");
        }
        Console.WriteLine("\n\n");


        return existingUserMealPlan;
    }


    public static Guid ModifyExistingMealPlan(Guid userId)
    {
        // Display the current meal plan to the uesr
        MealPlans userMealPlan = DisplayExistingMealPlan(userId);

        // Have the user choose which meal to modify
        int selectedMealToModify = SelectMealToModify(userId, userMealPlan);

        // Could have a separate method in Meals.cs to DisplayAllMeals that
        // calls the MealsLogic.cs method named GetStoredMeals()
        // (instead of calling this in SelectReplacementMeal)


        Console.WriteLine("Hit enter to continue.");
        Console.ReadLine();
        Console.Clear();
                
        return userId;
    }

    public static int SelectMealToModify(Guid userId, MealPlans userMealPlan)
    {
        // Have the user select the meal to change
        Console.WriteLine("Select the meal you want to change or enter 6 to return to the previous menu.");

        bool keepAlive = true;
        bool validUserInput;
        int userSelection;
        int selectedMealToModify = 0;
        do
        {
            try
            {
                Console.Write("Selection: ");
                userSelection = int.Parse(Console.ReadLine() ?? "");
                validUserInput = true;
                keepAlive = true;
                selectedMealToModify = userSelection-1;

                if (selectedMealToModify == 5)
                {
                    keepAlive = false;
                    Console.WriteLine("Okay, no changes have been made to your meal plan.");
                }
                else if (selectedMealToModify > 4 || selectedMealToModify < 0)
                {
                    validUserInput = false;
                    Console.WriteLine("Please enter a valid selection.");
                }
                else{
                    // Have the user select the meal they want to cook instead
                    userMealPlan = SelectReplacementMeal(userMealPlan, selectedMealToModify);

                    // Save the user's changes to their meal plan        
                    MealPlansLogic.SaveMealPlan(userId, userMealPlan);

                    // Confirm to the user that the changes have been made
                    Console.WriteLine("Your change has been saved!");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine($"{exception.Message}\nPlease enter a valid selection.");
                validUserInput = false;
                keepAlive = true;
            }

        } while (!validUserInput && keepAlive);

        return selectedMealToModify;
    }

public static MealPlans SelectReplacementMeal(MealPlans userMealPlan, int selectedMealToModify)
{
    List<Recipes> allRecipesInStorage = MealsLogic.GetStoredMeals();
        for (int i = 0; i<allRecipesInStorage.Count(); i++)
        {
            Console.WriteLine($"{i+1}. {allRecipesInStorage[i].MealName}");
        }

        // Ask for new input
        Console.Write("Which meal do you want to cook instead?: ");
        
        bool validUserInput;
        int userSelection;

        if (selectedMealToModify == 5)
        {return userMealPlan;}
        else{

        do
        {

            try
            {
                userSelection = int.Parse(Console.ReadLine() ?? "");
                validUserInput = true;
                
                int userSelectionIndex = userSelection-1;


                if (userSelectionIndex>allRecipesInStorage.Count())
                {validUserInput = false;
                Console.WriteLine("Please enter a valid selection.");}

                else
                {

                userMealPlan.recipeIds[selectedMealToModify] = allRecipesInStorage[userSelectionIndex].recipeId;
                userMealPlan.mealNames[selectedMealToModify] = allRecipesInStorage[userSelectionIndex].MealName;
                }

            }
            catch (Exception exception)
            {
                Console.WriteLine($"{exception.Message}\nPlease enter a valid selection.");
                validUserInput = false;
            }
        } while (!validUserInput);
        }
        return userMealPlan;
}
}

