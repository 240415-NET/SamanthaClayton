using Project1.Models;
using Project1.DataAccessLayer;
using System.Runtime.CompilerServices;

namespace Project1.LogicLayer;

public class GroceryListLogic
{
    private static IMealsStorageRepo _mealsData = new JsonMealsStorage();
    private static IMealPlansStorageRepo _userMealPlanData = new JsonMealPlansStorage();


    public static GroceryLists GetGroceryList(MealPlans userMealPlan)
    {
        GroceryLists userGroceryList = new GroceryLists();
        List<GroceryItems> userGroceryItems = new List <GroceryItems>();

        Random randomNumber = new Random(); 

        for (int i = 0; i<5; i++) // Create a list of 5 random numbers between [0 and 7) <-- not inclusive of 7
        {
            int randomInteger;
            do
            {
                randomInteger = randomNumber.Next(0, totalNumberofMealsInStorage);
            }
            while (randomIntegerList.Contains(randomInteger));
            
            randomIntegerList.Add(randomInteger);

        }


        List<Recipes> recipeListFromStorage = _mealsData.GetStoredMeals(randomIntegerList); // Calls the GetStoredMeals method and passes the random integer list to it
        List<Recipes> chosenRecipeList = new List<Recipes>();
        List<string> chosenMealNames = new List<string>();
       
        try{

        for (int i = 0; i < 5; i++)   // for each random integer we pass it, save the recipe at that index in a list
            {
               chosenRecipeList.Add(recipeListFromStorage[randomIntegerList[i]]);  // Adds the recipe from 
               chosenMealNames.Add(chosenRecipeList[i].MealName);
            }
        }
        catch (Exception e)
        {Console.WriteLine(e.Message);
        Console.WriteLine(e.StackTrace);}
        
        
        
        MealPlans newWeekOfMealsList = new MealPlans(chosenMealNames);

        return newWeekOfMealsList;
    }


public static void SaveMealPlan(Guid userId, MealPlans userMealPlan)
    {
        _userMealPlanData.StoreMealPlan(userId, userMealPlan);

    }

public static MealPlans GetMealPlan (Guid userId)
    {
        MealPlans existingUserMealPlan = _userMealPlanData.RetrieveUserMealPlan(userId);

        return existingUserMealPlan;
        

    }



}