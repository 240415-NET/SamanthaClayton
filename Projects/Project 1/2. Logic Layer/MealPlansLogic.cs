using Project1.Models;

namespace Project1.LogicLayer;

public class MealPlansLogic
{
    public static MealPlans GenerateNewMealPlan()
    {
        List<int> randomIntegerList = new List<int>();
        int totalNumberofMealsInStorage = GetMealsInStorage.count; // define this method in the Data Access Layer


        for (int i = 0; i<=5; i++)
        {
            Random randomNumber = new Random(totalNumberofMealsInStorage);
            int randomInteger = randomNumber.Next(totalNumberofMealsInStorage);
            randomIntegerList.Add(randomInteger);
        }

        MealPlans newMealPlan = new MealPlans();

        
    }


}