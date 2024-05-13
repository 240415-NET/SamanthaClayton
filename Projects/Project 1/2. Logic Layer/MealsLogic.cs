using Project1.Models;
using Project1.DataAccessLayer;

namespace Project1.LogicLayer;

public class MealsLogic
{

    private static IMealsStorageRepo _mealsData = new JsonMealsStorage();


    // If you call GetStoredMeals with no arguments, you get all meals in storage
    public static List<Recipes> GetStoredMeals()
    {
        List<Recipes> allRecipesInStorage = _mealsData.RetrieveMeals();
        return allRecipesInStorage;

    }


    // If you call GetStoredMeals and pass it an integer X, it will get you X random meals from storage
    public static MealPlans GetStoredMeals(int numberOfMealsToGet){
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


        List<Recipes> recipeListFromStorage = _mealsData.RetrieveMeals(); //  Retrieves all meals from storage
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


}