using System.Text.Json;
using Project1.Models;
using System.Data.SqlClient;

namespace Project1.DataAccessLayer;

public class SqlMealsStorage : IMealsStorageRepo
{
    private readonly string _connectionString;
    public SqlMealsStorage(string connectionString)
        {
            this._connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }


    public List<GroceryItems> RetrieveIngredientList (Guid recipeIdToFind)
    {
        List<GroceryItems> IngredientListFromStorage = new List<GroceryItems>();
        /*List<Recipes> recipesInStorage = new List<Recipes>();
        Recipes recipeToFind = new Recipes();
        

        string recipesInStorageJSON = File.ReadAllText(_filePath);                              // read the JSON
        recipesInStorage = JsonSerializer.Deserialize<List<Recipes>>(recipesInStorageJSON);    // deserialize the JSON and save as a list of recipes
        recipeToFind = recipesInStorage.FirstOrDefault(findmyrecipe => findmyrecipe.recipeId == recipeIdToFind);
        IngredientListFromStorage = recipeToFind.Ingredients;*/

        return IngredientListFromStorage;
    }

    public List<Recipes> RetrieveStoredMeals()
    {
        List<GroceryItems> IngredientListFromStorage = new List<GroceryItems>();
        List<Recipes> allRecipesInStorage = new List<Recipes>();
        /*

        string recipesInStorageJSON = File.ReadAllText(_filePath);                              // read the JSON
        allRecipesInStorage = JsonSerializer.Deserialize<List<Recipes>>(recipesInStorageJSON);    // deserialize the JSON and save as a list of recipes

        */
        return allRecipesInStorage;
    }
}
