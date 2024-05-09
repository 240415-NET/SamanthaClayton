namespace Project1.Models;

public interface IMealsStorageRepo
{
      public List<Recipes> GetStoredMeals(List<int> _mealsToGet);

      


}