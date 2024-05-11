using Project1.LogicLayer;

namespace Project1.Models;

public class GroceryListUI
{
//view or modify grocery list prompts

public static Guid DisplayGroceryList (Guid userId, MealPlans userMealPlan)
    {
    
        Console.WriteLine("Here's your grocery list!");
        List<GroceryItems> compiledGroceryList = GroceryListLogic.GetGroceryList(userMealPlan);
        for (int i = 0; i < compiledGroceryList.Count(); i++)
        {
            Console.WriteLine($"{compiledGroceryList[i].itemName}\t\t\t {compiledGroceryList[i].quantity} {compiledGroceryList[i].unitOfMeasure}");

        }
        return userId;
    }
}