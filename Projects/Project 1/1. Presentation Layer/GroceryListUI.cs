using Project1.LogicLayer;

namespace Project1.Models;

public class GroceryListUI
{
//view or modify grocery list prompts

public static Guid DisplayGroceryList (Guid userId, MealPlans userMealPlan)
    {
    
        Console.WriteLine("Here's your grocery list!");

        Console.WriteLine("Item Name\t\t\tQuantity");
        List<GroceryItems> compiledGroceryList = GroceryListLogic.GetGroceryList(userMealPlan);
        for (int i = 0; i < compiledGroceryList.Count(); i++)
        {
            if(compiledGroceryList[i].itemName.Length>=16)
            {Console.WriteLine($"{compiledGroceryList[i].itemName}\t\t{compiledGroceryList[i].quantity} {compiledGroceryList[i].unitOfMeasure}");}
            else if (compiledGroceryList[i].itemName.Length>=8)
            {Console.WriteLine($"{compiledGroceryList[i].itemName}\t\t\t{compiledGroceryList[i].quantity} {compiledGroceryList[i].unitOfMeasure}");}

            else
            {Console.WriteLine($"{compiledGroceryList[i].itemName}\t\t\t\t{compiledGroceryList[i].quantity} {compiledGroceryList[i].unitOfMeasure}");}

        }


        return userId;
    }
}