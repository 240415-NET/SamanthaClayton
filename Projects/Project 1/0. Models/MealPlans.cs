namespace Project1.Models;

public class MealPlans
{
    public List<Guid> recipeIds {get;set;}
    public List<string> mealNames {get; set;}

   public MealPlans(){}


    public MealPlans(List<Guid> _recipeIds, List<string> _mealNames)
    {
        recipeIds = _recipeIds;
        mealNames = _mealNames;
    }

}