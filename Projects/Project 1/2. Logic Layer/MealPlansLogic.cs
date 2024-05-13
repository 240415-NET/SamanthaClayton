using Project1.Models;
using Project1.DataAccessLayer;

namespace Project1.LogicLayer;

public class MealPlansLogic
{

    private static IMealsStorageRepo _mealsData = new JsonMealsStorage();
    private static IMealPlansStorageRepo _userMealPlanData = new JsonMealPlansStorage();

    
    public static void SaveMealPlan(Guid userId, MealPlans userMealPlan)
        {
            _userMealPlanData.StoreMealPlan(userId, userMealPlan);

        }

    public static MealPlans GetMealPlan (Guid userId)
        {
            MealPlans existingUserMealPlan = _userMealPlanData.RetrieveUserMealPlan(userId);

            return existingUserMealPlan;
            

        }



}