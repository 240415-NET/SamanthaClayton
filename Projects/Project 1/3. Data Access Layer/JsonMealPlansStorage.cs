using System.Text.Json;
using Project1.Models;

namespace Project1.DataAccessLayer;

public class JsonMealPlansStorage : IMealPlansStorageRepo
{
    public readonly static string _filePath = "./3. Data Access Layer/MealPlans.json";

    public void StoreMealPlan(Guid userId, MealPlans userMealPlan)
    {
        Dictionary<Guid, MealPlans> userMealPlanDictionary = new Dictionary<Guid, MealPlans>();

        
        if(File.Exists(_filePath))
        {
            string mealPlansInStorageJSON = File.ReadAllText(_filePath);
            Dictionary<Guid, MealPlans> mealPlansInStorage = JsonSerializer.Deserialize<Dictionary<Guid, MealPlans>>(mealPlansInStorageJSON);
            mealPlansInStorage.Remove(userId);
            mealPlansInStorage.Add(userId, userMealPlan);
            string revisedMealPlansInStorageJSON = JsonSerializer.Serialize<Dictionary<Guid, MealPlans>>(mealPlansInStorage);
            File.WriteAllText(_filePath, revisedMealPlansInStorageJSON);
        }
        else if (!File.Exists(_filePath))
        {
            Dictionary<Guid, MealPlans> freshMealPlansInStorage = new Dictionary<Guid, MealPlans>();
            freshMealPlansInStorage.Add(userId, userMealPlan);
            string freshMealPlansInStorageJSON = JsonSerializer.Serialize<Dictionary<Guid, MealPlans>>(freshMealPlansInStorage);
            File.WriteAllText(_filePath, freshMealPlansInStorageJSON);
        }
    }


    public MealPlans RetrieveUserMealPlan (Guid userIdToFind)
    {
        //KeyValuePair<Guid,MealPlans> userMealPlanPair = new KeyValuePair<Guid, MealPlans>();
        MealPlans existingUserMealPlan = new MealPlans();

        try
        {
            string mealPlansInStorageJSON = File.ReadAllText(_filePath);
            Dictionary<Guid, MealPlans> mealPlansInStorage = JsonSerializer.Deserialize<Dictionary<Guid, MealPlans>>(mealPlansInStorageJSON);
            existingUserMealPlan = mealPlansInStorage.FirstOrDefault(findmyuser => findmyuser.Key == userIdToFind).Value;
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }

        return existingUserMealPlan;

    }

}

