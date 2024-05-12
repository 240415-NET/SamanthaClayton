using Project1.Models;
using Project1.DataAccessLayer;

namespace Project1.LogicLayer;

public class MealPlansLogic
{

    private static IMealsStorageRepo _mealsData = new JsonMealsStorage();
    private static IMealPlansStorageRepo _userMealPlanData = new JsonMealPlansStorage();

    public static MealPlans GenerateNewMeals(int numberOfMealsToGet){
        List<int> randomIntegerList = new List<int>();
        int totalNumberofMealsInStorage = 7; // should I do GetStoredMeals.count and call the data access layer here and then again below?

        //Generate 5 random numbers ranging from 0 to the total number of meals in storage
        //These numbers will be used as indices to select meals at random from the stored meals list
        Random randomNumber = new Random(); 

        for (int i = 0; i< numberOfMealsToGet; i++) // Create a list of 5 random numbers between [0 and 7) <-- not inclusive of 7
        {
            int randomInteger;
            do
            {
                randomInteger = randomNumber.Next(0, totalNumberofMealsInStorage);
            }
            while (randomIntegerList.Contains(randomInteger));
            
            randomIntegerList.Add(randomInteger);

        }


        List<Recipes> recipeListFromStorage = _mealsData.RetrieveMeals(); // Calls the GetStoredMeals method and passes the random integer list to it
        List<Recipes> chosenRecipeList = new List<Recipes>();
        List<string> chosenMealNames = new List<string>();
        List<Guid>chosenRecipeIds = new List<Guid>();
       
        try{

        for (int i = 0; i < numberOfMealsToGet; i++)   // for each random integer we pass it, save the recipe at that index in a list
            {
               chosenRecipeList.Add(recipeListFromStorage[randomIntegerList[i]]);  // Adds the recipe from 
               chosenMealNames.Add(chosenRecipeList[i].MealName);
               chosenRecipeIds.Add(chosenRecipeList[i].recipeId);
            }
        }
        catch (Exception e)
        {Console.WriteLine(e.Message);
        Console.WriteLine(e.StackTrace);}
        
        
        MealPlans newMealList = new MealPlans(chosenRecipeIds, chosenMealNames);

        return newMealList;
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

public static List<Recipes> ViewAllMeals()
{
    List<Recipes> allRecipesInStorage = _mealsData.RetrieveMeals();
    return allRecipesInStorage;

}


}