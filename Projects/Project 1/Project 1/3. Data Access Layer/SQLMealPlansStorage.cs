using Project1.Models;
using System.Data.SqlClient;

namespace Project1.DataAccessLayer;

public class SQLMealPlansStorage : IMealPlansStorageRepo
{
    static string path = @"C:\Users\u41046\Revature Engineer Bootcamp\SamanthaClayton\Projects\Project 1\Project 1\ConnectionString.txt";
    string connectionString = File.ReadAllText(path);

    public void StoreUserMealPlan(Guid userId, MealPlans userMealPlan)
    {
        Dictionary<Guid, MealPlans> userMealPlanDictionary = new Dictionary<Guid, MealPlans>();

        // Could add a check if file path (SQL table) exists - if not, create the table
        using SqlConnection mySQLConnection = new SqlConnection(connectionString);

        mySQLConnection.Open();
        
        string SQLCodeToDeleteCurrentMealPlan = @"DELETE FROM UserMealPlans WHERE UserID = @UserId;";
        using SqlCommand DeleteOldMealPlanCommand = new SqlCommand(SQLCodeToDeleteCurrentMealPlan, mySQLConnection);
        DeleteOldMealPlanCommand.Parameters.AddWithValue("@UserId", userId);
        DeleteOldMealPlanCommand.ExecuteNonQuery();

          for (int i = 0; i < userMealPlan.mealNames.Count(); i++)
            {
                string SQLCodeToAddUserMealPlan =
                    @"INSERT INTO UserMealPlans (UserId, MealPlanId, RecipeId, RecipeName)
                    VALUES (@UserId, @MealPlanId, @RecipeId, @RecipeName);";

                using SqlCommand AddUserMealPlanCommand = new SqlCommand(SQLCodeToAddUserMealPlan, mySQLConnection);

                AddUserMealPlanCommand.Parameters.AddWithValue("@UserId", userId);
                AddUserMealPlanCommand.Parameters.AddWithValue("@MealPlanId", userMealPlan.mealPlanId);
                AddUserMealPlanCommand.Parameters.AddWithValue("@RecipeId", userMealPlan.recipeIds[i]);
                AddUserMealPlanCommand.Parameters.AddWithValue("@RecipeName", userMealPlan.mealNames[i]);
                AddUserMealPlanCommand.ExecuteNonQuery();

            }
        mySQLConnection.Close();
    }


    public MealPlans RetrieveUserMealPlan (Guid userIdToFind)
    {
        MealPlans existingUserMealPlan = new MealPlans();
        List<Guid> foundRecipeIds = new List<Guid>();
        List<string> foundMealNames = new List<string>();

        using SqlConnection myConnectionObject = new SqlConnection(this.connectionString);
        myConnectionObject.Open();
            
        string SQLCodeToRetrieveUser = @"SELECT * FROM UserMealPlans WHERE UserId = @UserId;";
            
            using SqlCommand RetrieveUserCommand = new SqlCommand(SQLCodeToRetrieveUser, myConnectionObject);
            RetrieveUserCommand.Parameters.AddWithValue("@UserId", userIdToFind);

            using SqlDataReader reader = RetrieveUserCommand.ExecuteReader();
        
            while (reader.Read())
                {
                    Guid userId = reader.GetGuid(0);
                    Guid mealPlanId = reader.GetGuid(1);
                    Guid recipeId = reader.GetGuid(2);
                    string mealName = reader.GetString(3);
                    foundRecipeIds.Add(recipeId);
                    foundMealNames.Add(mealName);
 
                    existingUserMealPlan = new MealPlans (mealPlanId, foundRecipeIds, foundMealNames);
                }

        myConnectionObject.Close();
        return existingUserMealPlan;

    }

}

