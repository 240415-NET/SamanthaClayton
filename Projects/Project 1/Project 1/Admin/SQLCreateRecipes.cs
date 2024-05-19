using Project1.LogicLayer;
using Project1.Models;
using System.Data.Common;
using System.Text.Json;
namespace Project1.PresentationLayer;
using System.Data.SqlClient;

public class SQLCreateRecipes
{
         public static void CreateInitialMealTables()
        {

            string path = @"C:\Users\u41046\Revature Engineer Bootcamp\SamanthaClayton\Projects\Project 1\Project 1\ConnectionString.txt";
            string connectionString = File.ReadAllText(path);

            // Connect to the SQL database by creating a SqlConnection object
            // Provide that object with the connection string
            using SqlConnection mySQLConnection = new SqlConnection(connectionString);

            // Create the object and then call a method off of it to open the connection to the database
            mySQLConnection.Open();

            //We then create a string, for the query or statement we are going to run, that allows us to update it's parameters later.
            string myCommandText =
                @"CREATE TABLE Recipe_Names(
                RecipeId UNIQUEIDENTIFIER NOT NULL,
                RecipeName NVARCHAR(255) NOT NULL
                );

                CREATE TABLE Recipe_Ingredients(
                RecipeId UNIQUEIDENTIFIER NOT NULL,
                IngredientId UNIQUEIDENTIFIER NOT NULL,
                IngredientName NVARCHAR(255),
                IngredientQuantity DEC(10, 2),
                IngredientUnitOfMeasurement NVARCHAR(255),
                IngredientStatus NVARCHAR(255)
                );

                CREATE TABLE Recipe_Steps(
                RecipeId UNIQUEIDENTIFIER NOT NULL,
                RecipeStepId UNIQUEIDENTIFIER NOT NULL,
                RecipeStepSequence int,
                RecipeStepDescription NVARCHAR(255)
                );
                ";
                
            //So we use the parameterized string above to create a SqlCommand object. 
            using SqlCommand myCommand = new SqlCommand(myCommandText, mySQLConnection);

            //We execute the above INSERT with this Execute non query. Because we are not querying the DB
            //we will execute this as a nonquery. 
            myCommand.ExecuteNonQuery();

            //We then close the connection, and after line 62 - our SqlConnection object is disposed of,
            //because we created it with that using statement above. 
            mySQLConnection.Close();
        }

        public static void AddNewRecipes(Recipes recipeToAdd)
        {
            string path = @"C:\Users\u41046\Revature Engineer Bootcamp\SamanthaClayton\Projects\Project 1\Project 1\ConnectionString.txt";
            string connectionString = File.ReadAllText(path);

            // Connect to the SQL database by creating a SqlConnection object
            // Provide that object with the connection string
            using SqlConnection mySQLConnection = new SqlConnection(connectionString);

            // Create the object and then call a method off of it to open the connection to the database
            mySQLConnection.Open();

            //We then create a string, for the query or statement we are going to run, that allows us to update it's parameters later.
            string myCommandTextForRecipeNamesTable =

                 @"INSERT INTO Recipe_Names (RecipeId, RecipeName)
                 VALUES (@RecipeId, @RecipeName);";

            //So we use the parameterized string above to create a SqlCommand object. 
            using SqlCommand myCommandForRecipeNamesTable = new SqlCommand(myCommandTextForRecipeNamesTable, mySQLConnection);

            myCommandForRecipeNamesTable.Parameters.AddWithValue("@RecipeId", recipeToAdd.recipeId);
            myCommandForRecipeNamesTable.Parameters.AddWithValue("@RecipeName", recipeToAdd.MealName);

            //We execute the above INSERT with this Execute non query. Because we are not querying the DB
            //we will execute this as a nonquery. 
            myCommandForRecipeNamesTable.ExecuteNonQuery();




           for (int i = 0; i < recipeToAdd.Ingredients.Count(); i++)
            
                {
                    string myCommandTextForRecipeIngredientsTable =
                        @"INSERT INTO Recipe_Ingredients (RecipeId, IngredientId, IngredientName, IngredientQuantity, IngredientUnitOfMeasurement, IngredientStatus)
                        VALUES (@RecipeId, @IngredientId, @IngredientName, @IngredientQuantity, @IngredientUnitOfMeasurement, @IngredientStatus);";
                    using SqlCommand myCommandForRecipeIngredientsTable = new SqlCommand(myCommandTextForRecipeIngredientsTable, mySQLConnection);

                    myCommandForRecipeIngredientsTable.Parameters.AddWithValue("@RecipeId", recipeToAdd.recipeId);
                    myCommandForRecipeIngredientsTable.Parameters.AddWithValue("@IngredientId", recipeToAdd.Ingredients[i].ingredientId);
                    myCommandForRecipeIngredientsTable.Parameters.AddWithValue("@IngredientName", recipeToAdd.Ingredients[i].itemName);
                    myCommandForRecipeIngredientsTable.Parameters.AddWithValue("@IngredientQuantity", recipeToAdd.Ingredients[i].quantity);
                    myCommandForRecipeIngredientsTable.Parameters.AddWithValue("@IngredientUnitOfMeasurement", recipeToAdd.Ingredients[i].unitOfMeasure);
                    myCommandForRecipeIngredientsTable.Parameters.AddWithValue("@IngredientStatus", recipeToAdd.Ingredients[i].purchased);
                    myCommandForRecipeIngredientsTable.ExecuteNonQuery();
                }

            for (int j = 0; j < recipeToAdd.RecipeSteps.Count(); j++)
                {
                    string myCommandTextForRecipeStepsTable = 
                        @"INSERT INTO Recipe_Steps (RecipeId, RecipeStepId, RecipeStepSequence, RecipeStepDescription)
                        VALUES (@RecipeId, @RecipeStepId, @RecipeStepSequence, @RecipeStepDescription);";
                    using SqlCommand myCommandForRecipeStepsTable = new SqlCommand(myCommandTextForRecipeStepsTable, mySQLConnection);
                    myCommandForRecipeStepsTable.Parameters.AddWithValue("@RecipeId", recipeToAdd.recipeId);
                    myCommandForRecipeStepsTable.Parameters.AddWithValue("@RecipeStepId", recipeToAdd.RecipeSteps[j].recipeStepId);
                    myCommandForRecipeStepsTable.Parameters.AddWithValue("@RecipeStepSequence", recipeToAdd.RecipeSteps[j].recipeStepSequence);
                    myCommandForRecipeStepsTable.Parameters.AddWithValue("@RecipeStepDescription", recipeToAdd.RecipeSteps[j].recipeStepDescription);
                    myCommandForRecipeStepsTable.ExecuteNonQuery();

                }



            //We then close the connection, and after line 62 - our SqlConnection object is disposed of,
            //because we created it with that using statement above. 
            mySQLConnection.Close();


        }


    public static void CreateRecipes()

    
    {
        CreateInitialMealTables();

        // RECIPE 1: CHICKEN & BROCCOLI STIRFRY
        GroceryItems recipe1ingredient1 = new GroceryItems("Chicken Breasts", 1, "pound", "No");
        GroceryItems recipe1ingredient2 = new GroceryItems("Broccoli", 1, "head", "No");
        GroceryItems recipe1ingredient3 = new GroceryItems("Avocado Oil", 2, "tbsp.", "No");
        GroceryItems recipe1ingredient4 = new GroceryItems("Garlic Powder", 1, "tsp.", "No");
        GroceryItems recipe1ingredient5 = new GroceryItems("Salt", 1, "tsp.", "No");
        GroceryItems recipe1ingredient6 = new GroceryItems("Pepper", 1, "tsp.", "No");

        List<GroceryItems> recipe1ingredients = [recipe1ingredient1, recipe1ingredient2, recipe1ingredient3,
                                                recipe1ingredient4, recipe1ingredient5, recipe1ingredient6];


        RecipeSteps recipe1step1 = new RecipeSteps(1, "Cut chicken into 1\" cubes");
        RecipeSteps recipe1step2 = new RecipeSteps(2, "Cut broccoli into bite-sized florets");
        RecipeSteps recipe1step3 = new RecipeSteps(3, "Heat avocado oil in saute pan on medium-high heat");
        RecipeSteps recipe1step4 = new RecipeSteps(4, "Add chicken and broccoli to pan and cook until chicken reaches an internal temperature of 165 degrees Fahrenheit");

        List<RecipeSteps> recipe1steps = [recipe1step1, recipe1step2, recipe1step3, recipe1step4];


        Recipes recipe1 = new Recipes("Chicken & Broccoli Stir Fry", recipe1ingredients, recipe1steps);
        
        // RECIPE 2: PASTA WITH HOMEMADE PESTO
        GroceryItems recipe2ingredient1 = new GroceryItems("Spaghetti", 1, "box", "No");
        GroceryItems recipe2ingredient2 = new GroceryItems("Basil", 2, "cups", "No");
        GroceryItems recipe2ingredient3 = new GroceryItems("Garlic", 4, "cloves", "No");
        GroceryItems recipe2ingredient4 = new GroceryItems("Pine Nuts", 1, "cup", "No");
        GroceryItems recipe2ingredient5 = new GroceryItems("Olive Oil", 0.5, "cup", "No");
        GroceryItems recipe2ingredient6 = new GroceryItems("Salt", 1, "tsp.", "No");

        List<GroceryItems> recipe2ingredients = [recipe2ingredient1, recipe2ingredient2, recipe2ingredient3,
                                                recipe2ingredient4, recipe2ingredient5, recipe2ingredient6];

        RecipeSteps recipe2step1 = new RecipeSteps(1, "Bring a large pot of water to boil");
        RecipeSteps recipe2step2 = new RecipeSteps(2, "Add spaghetti and cook for length of time recommended on package");
        RecipeSteps recipe2step3 = new RecipeSteps(3, "While spaghetti cooks, add all other ingredients to a blender or food processor and blend");
        RecipeSteps recipe2step4 = new RecipeSteps(4, "Drain pasta\n5. Stir pesto and pasta together and serve");

        List<RecipeSteps> recipe2steps = [recipe2step1, recipe2step2, recipe2step3, recipe2step4];


        Recipes recipe2 = new Recipes("Pasta with Homemade Pesto", recipe2ingredients, recipe2steps);


        // RECIPE 3: BUFFALO CHICKEN STUFFED BAKED POTATOES

        GroceryItems recipe3ingredient1 = new GroceryItems("Chicken Breasts", 1, "pound", "No");
        GroceryItems recipe3ingredient2 = new GroceryItems("Buffalo Sauce", 1, "jar", "No");
        GroceryItems recipe3ingredient3 = new GroceryItems("Potatoes", 4, "whole", "No");
        GroceryItems recipe3ingredient4 = new GroceryItems("Ranch", 0.5, "cup", "No");
        GroceryItems recipe3ingredient5 = new GroceryItems("Pepper", 1, "tsp.", "No");
        GroceryItems recipe3ingredient6 = new GroceryItems("Salt", 1, "tsp.", "No");
        GroceryItems recipe3ingredient7 = new GroceryItems("Butter", 1, "tbsp.", "No");


        List<GroceryItems> recipe3ingredients = [recipe3ingredient1, recipe3ingredient2, recipe3ingredient3,
                                                recipe3ingredient4, recipe3ingredient5, recipe3ingredient6,
                                                recipe3ingredient7];

        RecipeSteps recipe3step1 = new RecipeSteps(1, "Pre-heat oven to 400 degrees");
        RecipeSteps recipe3step2 = new RecipeSteps(2, "Wash potatoes and wrap each one in foil and place in oven");
        RecipeSteps recipe3step3 = new RecipeSteps(3, "Let the potatoes cook for about 30 minutes and then start on the next steps");
        RecipeSteps recipe3step4 = new RecipeSteps(4, "Put chicken in a large pot and fill it with water until the chicken is fully covered and then some");
        RecipeSteps recipe3step5 = new RecipeSteps(5, "Put pot on the stove on medium high heat until the water boils ");
        RecipeSteps recipe3step6 = new RecipeSteps(6, "Once the water boils, turn the heat down to medium and cook until the chicken is cooked through");
        RecipeSteps recipe3step7 = new RecipeSteps(7, "Once the chicken is cooked through, shred the chicken");
        RecipeSteps recipe3step8 = new RecipeSteps(8, "Stir the buffalo and chicken to coat the chicken in sauce");
        RecipeSteps recipe3step9 = new RecipeSteps(9, "When the potatoes are done, cut each potato down the center and"+
                                                      "top with butter, salt, pepper, the shredded chicken coated in sauce, and ranch.");

        List<RecipeSteps> recipe3steps = [recipe3step1,
                                          recipe3step2,
                                          recipe3step3,
                                          recipe3step4,
                                          recipe3step5,
                                          recipe3step6,
                                          recipe3step7,
                                          recipe3step8,
                                          recipe3step9];

        Recipes recipe3 = new Recipes("Buffalo Chicken Stuffed Baked Potatoes", recipe3ingredients, recipe3steps);


        // RECIPE 4: GRILLED CHEESE SANDWICH

        GroceryItems recipe4ingredient1 = new GroceryItems("White Bread", 2, "slices", "No");
        GroceryItems recipe4ingredient2 = new GroceryItems("Butter", 0.5, "tbsp", "No");
        GroceryItems recipe4ingredient3 = new GroceryItems("Cheese", 2, "slices", "No");



        List<GroceryItems> recipe4ingredients = [recipe4ingredient1, recipe4ingredient2, recipe4ingredient3];

        RecipeSteps recipe4step1 = new RecipeSteps(1, "Butter 1 side of each slice of bread");
        RecipeSteps recipe4step2 = new RecipeSteps(2, "Place the buttered side of 1 slice of bread into a hot pan on medium heat");
        RecipeSteps recipe4step3 = new RecipeSteps(3, "Add the cheese slices on top of the bread");
        RecipeSteps recipe4step4 = new RecipeSteps(4, "Put the other slice of bread on top with the buttered side facing up");
        RecipeSteps recipe4step5 = new RecipeSteps(5, "Cook until the bottom is golden brown");
        RecipeSteps recipe4step6 = new RecipeSteps(6, "Flip sandwich over and cook until the other side is golden brown too");

        List<RecipeSteps> recipe4steps = [recipe4step1,
                                          recipe4step2,
                                          recipe4step3,
                                          recipe4step4,
                                          recipe4step5,
                                          recipe4step6];

        Recipes recipe4 = new Recipes("Grilled Cheese Sandwich", recipe4ingredients, recipe4steps);

        // RECIPE 5: GIRL DINNER

        GroceryItems recipe5ingredient1 = new GroceryItems("Salami", 3, "slices", "No");
        GroceryItems recipe5ingredient2 = new GroceryItems("Grapes", 1, "bunch", "No");
        GroceryItems recipe5ingredient3 = new GroceryItems("Crackers", 1, "cup", "No");
        GroceryItems recipe5ingredient4 = new GroceryItems("Goat Cheese", 3, "ounces", "No");
        GroceryItems recipe5ingredient5 = new GroceryItems("Turkey", 2, "slices", "No");
        GroceryItems recipe5ingredient6 = new GroceryItems("Apple", 1, "whole", "No");


        List<GroceryItems> recipe5ingredients = [recipe5ingredient1, recipe5ingredient2, recipe5ingredient3,
                                                recipe5ingredient4, recipe5ingredient5, recipe5ingredient6];

        RecipeSteps recipe5step1 = new RecipeSteps(1, "Cut the apple into slices");
        RecipeSteps recipe5step2 = new RecipeSteps(2, "Arrange ingredients on a plate");


        List<RecipeSteps> recipe5steps = [recipe5step1,
                                          recipe5step2];


        Recipes recipe5 = new Recipes("Girl Dinner", recipe5ingredients, recipe5steps);

        // RECIPE 6: TURKEY BLTA SANDWICH

        GroceryItems recipe6ingredient1 = new GroceryItems("White Bread", 2, "slices", "No");
        GroceryItems recipe6ingredient2 = new GroceryItems("Turkey", 3, "slices", "No");
        GroceryItems recipe6ingredient3 = new GroceryItems("Bacon", 2, "slices", "No");
        GroceryItems recipe6ingredient4 = new GroceryItems("Lettuce", 2, "leaves", "No");
        GroceryItems recipe6ingredient5 = new GroceryItems("Mayonnaise", 0.5, "tbsp.", "No");
        GroceryItems recipe6ingredient6 = new GroceryItems("Avocado", 0.5, "Whole", "No");
        GroceryItems recipe6ingredient7 = new GroceryItems("Tomato", 0.5, "Whole", "No");


        List<GroceryItems> recipe6ingredients = [recipe6ingredient1, recipe6ingredient2, recipe6ingredient3,
                                                recipe6ingredient4, recipe6ingredient5, recipe6ingredient6,
                                                recipe6ingredient7];
        
        RecipeSteps recipe6step1 = new RecipeSteps(1, "Slice the tomato and avacado");
        RecipeSteps recipe6step2 = new RecipeSteps(2, "Assemble the sandwich");


        List<RecipeSteps> recipe6steps = [recipe6step1,
                                          recipe6step2];

        Recipes recipe6 = new Recipes("Turkey BLTA Sandwich", recipe6ingredients, recipe6steps);

        
        // RECIPE 7: CAPRESE SALAD

        GroceryItems recipe7ingredient1 = new GroceryItems("Mozzarella", 2, "ounces", "No");
        GroceryItems recipe7ingredient2 = new GroceryItems("Grape Tomatoes", 8, "ounces", "No");
        GroceryItems recipe7ingredient3 = new GroceryItems("Basil", 2, "cups", "No");
        GroceryItems recipe7ingredient4 = new GroceryItems("Olive Oil", 1, "tbsp.", "No");
        GroceryItems recipe7ingredient5 = new GroceryItems("Balsamic Vinegar", 1, "tbsp.", "No");
        GroceryItems recipe7ingredient6 = new GroceryItems("Salt", 0.5, "tsp.", "No");
        GroceryItems recipe7ingredient7 = new GroceryItems("Pepper", 0.5, "tsp.", "No");


        List<GroceryItems> recipe7ingredients = [recipe7ingredient1, recipe7ingredient2, recipe7ingredient3,
                                                recipe7ingredient4, recipe7ingredient5, recipe7ingredient6,
                                                recipe7ingredient7];

        RecipeSteps recipe7step1 = new RecipeSteps(1, "Cut the mozzarella into bite-sized pieces");
        RecipeSteps recipe7step2 = new RecipeSteps(2, "Tear/roughly chop the basil");
        RecipeSteps recipe7step3 = new RecipeSteps(3, "Add all ingredients to a salad bowl and mix well");


        List<RecipeSteps> recipe7steps = [recipe7step1,
                                          recipe7step2,
                                          recipe7step3];



        Recipes recipe7 = new Recipes("Caprese Salad", recipe7ingredients, recipe7steps);
    
    
        AddNewRecipes(recipe1);
        AddNewRecipes(recipe2);
        AddNewRecipes(recipe3);
        AddNewRecipes(recipe4);
        AddNewRecipes(recipe5);
        AddNewRecipes(recipe6);
        AddNewRecipes(recipe7);

        }

       public static void CreateInitialMealPlanandUserTables()
        {

            string path = @"C:\Users\u41046\Revature Engineer Bootcamp\SamanthaClayton\Projects\Project 1\Project 1\ConnectionString.txt";
            string connectionString = File.ReadAllText(path);

            // Connect to the SQL database by creating a SqlConnection object
            // Provide that object with the connection string
            using SqlConnection mySQLConnection = new SqlConnection(connectionString);

            // Create the object and then call a method off of it to open the connection to the database
            mySQLConnection.Open();

            //We then create a string, for the query or statement we are going to run, that allows us to update it's parameters later.
            string myCommandText =
                @"CREATE TABLE Users(
                UserId UNIQUEIDENTIFIER NOT NULL,
                UserName NVARCHAR(255) NOT NULL
                );

                CREATE TABLE UserMealPlans(
                UserId UNIQUEIDENTIFIER NOT NULL,
                MealPlanId UNIQUEIDENTIFIER NOT NULL,
                RecipeId UNIQUEIDENTIFIER
                );";
                
            //So we use the parameterized string above to create a SqlCommand object. 
            using SqlCommand commandToCreateUserAndUserMealPlanTables = new SqlCommand(myCommandText, mySQLConnection);

            //We execute the above INSERT with this Execute non query. Because we are not querying the DB
            //we will execute this as a nonquery. 
            commandToCreateUserAndUserMealPlanTables.ExecuteNonQuery();

            //We then close the connection, and after line 62 - our SqlConnection object is disposed of,
            //because we created it with that using statement above. 
            mySQLConnection.Close();
        }
    }
    