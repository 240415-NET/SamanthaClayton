namespace Project1.Models;

public interface IMealPlansStorageRepo
{
    public void StoreUserMealPlan(Guid userId, MealPlans userMealPlan);
    public MealPlans RetrieveUserMealPlan (Guid userIdToFind);

}