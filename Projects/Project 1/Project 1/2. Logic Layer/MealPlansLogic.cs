using Project1.Models;
using Project1.DataAccessLayer;

namespace Project1.LogicLayer;

public class MealPlansLogic
{

   // private static IMealPlansStorageRepo _userMealPlanData = new JsonMealPlansStorage();
        private static IMealPlansStorageRepo _userMealPlanData = new SQLMealPlansStorage();


    
    public static void SaveMealPlan(Guid userId, MealPlans userMealPlan)
        {
            _userMealPlanData.StoreUserMealPlan(userId, userMealPlan);

        }

    public static MealPlans GetMealPlan (Guid userId)
        {
            MealPlans existingUserMealPlan = _userMealPlanData.RetrieveUserMealPlan(userId);

            return existingUserMealPlan;
            

        }

    public static bool CheckIfMealPlanExists(Guid userId)
    {
        if(_userMealPlanData.RetrieveUserMealPlan(userId) != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


}