using System.Text.Json;
using Project1.Models;
using System.Data.SqlClient;
using System.Data;

namespace Project1.DataAccessLayer;

public class SQLMealsStorage : IMealsStorageRepo
{
    private readonly string _connectionString;
    public SQLMealsStorage(string connectionString)
        {
            this._connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

    public List<GroceryItems> RetrieveIngredientList (Guid recipeIdToFind)
    {
        List<GroceryItems> IngredientListFromStorage = new List<GroceryItems>();
        using SqlConnection myConnectionObject = new SqlConnection(this._connectionString);
        myConnectionObject.Open();
        
        string commandTextForRetrievingIngredientList = @"SELECT * FROM Recipe_Ingredients WHERE RecipeId = @RecipeId;";
        //cast('@RecipeId' as uniqueidentifier);";
        
        using SqlCommand commandForRetrievingIngredientList = new SqlCommand(commandTextForRetrievingIngredientList, myConnectionObject);
        commandForRetrievingIngredientList.Parameters.AddWithValue("@RecipeId", recipeIdToFind);

        using SqlDataReader reader = commandForRetrievingIngredientList.ExecuteReader();
    
        while (reader.Read())
            {

                Guid recipeId = reader.GetGuid(0);
                Guid ingredientId = reader.GetGuid(1);
                string ingredientName = reader.GetString(2);
                double quantity = (double) reader.GetDecimal(3);
                string unitOfMeasure = reader.GetString(4);
                string purchased = reader.GetString(5);
                GroceryItems ingredientfromstorage  = new GroceryItems(ingredientName, quantity, unitOfMeasure, purchased);
                IngredientListFromStorage.Add(ingredientfromstorage);
            }      
        


        return IngredientListFromStorage;
    }

    public List<Recipes> RetrieveStoredMeals()
    {
        List<Recipes> allRecipesInStorage = new List<Recipes>();

        using SqlConnection myConnectionObject = new SqlConnection(this._connectionString);
        myConnectionObject.Open();
        
        string commandTextForRetrievingStoredMeals = @"SELECT * FROM Recipe_Names;";
        
        using SqlCommand commandForRetrievingStoredMeals = new SqlCommand(commandTextForRetrievingStoredMeals, myConnectionObject);

        using SqlDataReader reader = commandForRetrievingStoredMeals.ExecuteReader();

        while (reader.Read())
            {
                Guid recipeId = reader.GetGuid(0);
                string mealname = reader.GetString(1);
                Recipes recipeFromStorage  = new Recipes(recipeId, mealname);
                allRecipesInStorage.Add(recipeFromStorage);
            }      
        return allRecipesInStorage;
    }
}
