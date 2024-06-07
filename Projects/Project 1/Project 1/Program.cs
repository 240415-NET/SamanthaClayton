using Project1.PresentationLayer;

namespace Project1;

class Program
{
    static void Main(string[] args)
    {
        Menus.StartMenu();


        // This method creates a json file and fills it with a set of 7 meals/recipes.  We only need to create this json file once.
        //JsonCreateRecipes.CreateRecipes();

        // This method creates the SQL tables that are needed & loads the Recipe_Names, Recipe_Ingredients, and Recipe_Steps tables with recipe information for 7 meals/recipes.
        // The Users and UserMealPlans SQL tables are created as empty tables & only begin to store data once a user uses the app.
        //SQLCreateRecipes.CreateInitialSQLTables();
    }
}
