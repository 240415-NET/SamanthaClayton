using System.Text.Json;
using Project1.Models;

namespace Project1.DataAccessLayer;

public class JsonMealsStorage : IMealsStorageRepo
{
    public readonly static string _filePath = "./3. Data Access Layer/Meals.json";

    public List<Recipes> GetStoredMeals(List<int> _mealsToGet)
    {
    
        //List<Recipes> recipesInStorage = new List<Recipes>();
        List<Recipes> retrievedRecipesFromStorage = new List<Recipes>();
        List<string> retrievedMealNamesFromStorage = new List<string>();
        List<Recipes>recipesInStorage = new List<Recipes>();
        
        try
        {
            string recipesInStorageJSON = File.ReadAllText(_filePath);                              // read the JSON
            recipesInStorage = JsonSerializer.Deserialize<List<Recipes>>(recipesInStorageJSON);    // deserialize the JSON and save as a list of recipes

            
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message + exception.StackTrace);
        }

        //MealPlans newMealPlanMealsList = new MealPlans(retrievedMealNamesFromStorage);                // create a meal plan using the list of meal names we got rom storage

     return recipesInStorage;  
    }
}

