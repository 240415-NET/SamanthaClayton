using System.Text.Json;
using Project1.Models;

namespace Project1.DataAccessLayer;

public class MealsStorage
{
    public readonly static string _filePath = "./3. Data Access Layer/Meals.json";

    public static MealPlans GetStoredMeals(List<int> _mealsToGet) //make this receive a list of integers
    {
    
        //List<Recipes> recipesInStorage = new List<Recipes>();
        List<Recipes> retrievedRecipesFromStorage = new List<Recipes>();
        List<string> retrievedMealNamesFromStorage = new List<string>();
        
        try
        {
            string recipesInStorageJSON = File.ReadAllText(_filePath);                              // read the JSON
            List<Recipes> recipesInStorage = JsonSerializer.Deserialize<List<Recipes>>(recipesInStorageJSON);     // deserialize the JSON and save as a list of recipes
    
            
            
           for (int i = 0; i < _mealsToGet.Count(); i++)                                           // for each random integer we pass it, save the recipe at that index in a list
            {
              //retrievedRecipesFromStorage[i] = recipesInStorage.FirstOrDefault(recipe => recipe.MealName == "Grilled Cheese Sandwich");
               retrievedRecipesFromStorage[i] = recipesInStorage[_mealsToGet[i]];                  //gets the recipes from storage using the index 
            }
            for (int i = 0; i <_mealsToGet.Count(); i++)                                            // for each random integer we pass it, save the recipe's meal name to a list of strings
            {
                retrievedMealNamesFromStorage[i] = retrievedRecipesFromStorage[i].MealName;
            }

            
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message + exception.StackTrace);
        }

        MealPlans newMealPlanMealsList = new MealPlans(retrievedMealNamesFromStorage);                // create a meal plan using the list of meal names we got rom storage

        return newMealPlanMealsList;  
    }
}

