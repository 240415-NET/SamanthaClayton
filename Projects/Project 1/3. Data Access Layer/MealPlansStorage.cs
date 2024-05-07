using System.Text.Json;

namespace Project1.DataAccessLayer;

public class MealPlansStorage
{
        public readonly static string _filePath = "./3. Data Access Layer/Meals.json";


    public static List<string> GetStoredMeals() //make this receive a list of integers
    {
        List<string> mealsInStorageList = new List<string>();
        // Need to add in logic to take in a list of random integers, filter to the meals in those random integers, and send those meals back to the MealPlansLogic layer
        try
        {
            string mealsInStorageJSON = File.ReadAllText(_filePath);
            mealsInStorageList = JsonSerializer.Deserialize<List<string>>(mealsInStorageJSON);
            //newMealPlanMealsList = filtered version of mealsInStorageList
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }

        return newMealPlanMealsList;

            
    }




}