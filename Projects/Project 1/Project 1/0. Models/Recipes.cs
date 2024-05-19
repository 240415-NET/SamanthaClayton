namespace Project1.Models;

public class Recipes
{
    public Guid recipeId {get;set;}
    public string? MealName {get;set;}
    public List<GroceryItems>? Ingredients {get; set;}
    public List<RecipeSteps>? RecipeSteps {get; set;}

    public Recipes(){} // Added this to fix the issue with the json deserializer

    public Recipes (string _mealName, List<GroceryItems> _ingredients, List<RecipeSteps> _recipeSteps)
    {
        recipeId = Guid.NewGuid();
        MealName = _mealName;
        Ingredients = _ingredients;
        RecipeSteps = _recipeSteps;
    }

    public Recipes(Guid _recipeId, string _mealName)
    {
        recipeId = _recipeId;
        MealName = _mealName;
    }
       

    
}