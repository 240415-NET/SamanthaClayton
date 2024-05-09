using System.Text.Json;

namespace Project1.DataAccessLayer;

/*public class MealStorage
{
    public readonly static string _filePath = "./3. Data Access Layer/Meals.json";

    public static void StoreMeal(M)
    {
        if(File.Exists(_filePath))
        {
            string usersInStorageJSON = File.ReadAllText(_filePath);
            List<Users> usersInStorageList = JsonSerializer.Deserialize<List<Users>>(usersInStorageJSON);
            usersInStorageList.Add(newUser);
            string revisedUsersInStorageJSON = JsonSerializer.Serialize<List<Users>>(usersInStorageList);
            File.WriteAllText(_filePath, revisedUsersInStorageJSON);
        }
        else if (!File.Exists(_filePath))
        {
            List<Users> freshUsersInStorageList = new List<Users>();
            freshUsersInStorageList.Add(newUser);
            string freshUsersInStorageJSON = JsonSerializer.Serialize<List<Users>>(freshUsersInStorageList);
            File.WriteAllText(_filePath, freshUsersInStorageJSON);
        }
    }


    public static List<string> GetStoredMeals(List<int> _mealsToGet) //make this receive a list of integers
    {
    
        List<string> mealsInStorageList = new List<string>();
        List<string> mealsFromStorageList = new List<string>();
        
        // Need to add in logic to take in a list of random integers, filter to the meals in those random integers, and send those meals back to the MealPlansLogic layer
        try
        {
            string mealsInStorageJSON = File.ReadAllText(_filePath);
            mealsInStorageList = JsonSerializer.Deserialize<List<string>>(mealsInStorageJSON);
            for (int i = 0; i < _mealsToGet.Count(); i++)
            {
                mealsFromStorageList[i] = mealsInStorageList[_mealsToGet[i]];
            }

            
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }

        return newMealPlanMealsList;  
    }
}*/

