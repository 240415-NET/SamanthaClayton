using Project1.Models;
using Project1.DataAccessLayer;

namespace Project1.LogicLayer;

public class GroceryListLogic
{
    private static IMealsStorageRepo _mealsData = new JsonMealsStorage();

    public static List<GroceryItems> GetGroceryList(MealPlans userMealPlan)
        {
            List<GroceryItems> IngredientListFromRecipes = new List<GroceryItems>();

            for (int i = 0; i<userMealPlan.mealNames.Count(); i++) 
            {
            Guid recipeIdToFind = userMealPlan.recipeIds[i]; // Get the recipeId for each meal in the meal plan
            List<GroceryItems> ingredientsFromRecipeToFind = _mealsData.RetrieveIngredientList(recipeIdToFind); // Retrieve the ingredient list from storage for each recipeId in the meal plan
            
            for (int j = 0; j<ingredientsFromRecipeToFind.Count(); j++)
                {
                    IngredientListFromRecipes.Add(ingredientsFromRecipeToFind[j]);
                }
            }

            List<GroceryItems> compiledGroceryList = CompileIngredientLists(IngredientListFromRecipes);
            return compiledGroceryList;
            

        }

    public static List<GroceryItems> CompileIngredientLists(List<GroceryItems> ingredientListFromRecipes)
    {
        List<GroceryItems> compiledGroceryList = new List<GroceryItems>();
        List<GroceryItems>intermediateList = new List<GroceryItems>();


        for (int i = 0; i<ingredientListFromRecipes.Count(); i++) // Iterate through every item in the mega ingredient list that was compiled from each recipe
        {
            // If the compiledGroceryList isn't empty & if the current item already exists in our final grocery list, move on to the next item
            bool itemAlreadyInCompiledList = compiledGroceryList.Any(groceryitem=>groceryitem.itemName == ingredientListFromRecipes[i].itemName);
            if (itemAlreadyInCompiledList)
            {

                continue;
            }

            // If the current item doesn't already exist in our final grocery list, we're gonna need to add it,
            // but we need to check if there are any other instances of the same item in our list.  If so,
            // we'll need to combine them so we can have (for example) Chicken 2 pounds instead of Chicken 1 pound
            // repeating twice if 2 recipes require 1 pound of chicken.
        else
            {
                intermediateList.Clear();
                intermediateList.Add(ingredientListFromRecipes[i]); // Add current item to an intermediate list
                GroceryItems itemToAdd = new GroceryItems();


                // Check the remaining ingredients to see if they have the same name as the current item we're looking at
                // If so, add that item to our intermediate list
                for (int j = i+1; j<ingredientListFromRecipes.Count(); j++) 
                {
                        if (ingredientListFromRecipes[i].itemName == ingredientListFromRecipes[j].itemName)
                        {
                            intermediateList.Add(ingredientListFromRecipes[j]);
                        }
                }
                
                // The item to add is the item in the intermediate list with all the quantities summed up
                itemToAdd.itemName = intermediateList[0].itemName;
                itemToAdd.unitOfMeasure = intermediateList[0].unitOfMeasure;
                itemToAdd.quantity = 0;
                for (int k = 0; k<intermediateList.Count(); k++)
                {
                    itemToAdd.quantity = itemToAdd.quantity + intermediateList[k].quantity;
                }

                compiledGroceryList.Add(itemToAdd); // Add the item to the final grocery list

        }
        }


        return compiledGroceryList;


        }
        


}
