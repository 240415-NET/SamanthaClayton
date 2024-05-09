using Project1.Models;
using Project1.DataAccessLayer;

namespace Project1.LogicLayer;

public class MealPlansLogic
{
    public static MealPlans GenerateNewMealPlan()
    {
        List<int> randomIntegerList = new List<int>();
        int totalNumberofMealsInStorage = 7; // should I do GetStoredMeals.count and call the data access layer here and then again below?

        //Generate 5 random numbers ranging from 0 to the total number of meals in storage
        //These numbers will be used as indices to select meals at random from the stored meals list
        for (int i = 0; i<5; i++)
        {
            Random randomNumber = new Random(totalNumberofMealsInStorage); 
            int randomInteger = randomNumber.Next(0, totalNumberofMealsInStorage);
            randomIntegerList.Add(randomInteger);
        }


        MealPlans newMealPlan = MealsStorage.GetStoredMeals(randomIntegerList); // Calls the GetStoredMeals method and passes the random integer list to it


        return newMealPlan;
    }


}