namespace Project1.Models;

public class Recipes
{
    public string? MealName {get;set;}
    public List<GroceryItems>? Ingredients {get; set;}
    public string? RecipeSteps {get; set;}

    public Recipes(){} // Added this to fix the issue with the json deserializer

    public Recipes (string _mealName, List<GroceryItems> _ingredients, string _recipeSteps)
    {
        MealName = _mealName;
        Ingredients = _ingredients;
        RecipeSteps = _recipeSteps;
    }

       

    
}