namespace Project1.Models;

public interface IMealsStorageRepo
{
      //public List<Recipes> RetrieveStoredMeals();

      public List<GroceryItems> RetrieveIngredientList (Guid recipeIdToFind);

      public List<Recipes> RetrieveMeals();


}