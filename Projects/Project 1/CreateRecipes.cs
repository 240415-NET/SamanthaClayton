using Project1.LogicLayer;
using Project1.Models;
using System.Text.Json;
namespace Project1.PresentationLayer;

public class CreatRecipes
{

    public readonly static string _filePath = "./3. Data Access Layer/Meals.json";

    public static void CreateRecipes()

    
    {

        // RECIPE 1: CHICKEN & BROCCOLI STIRFRY
        GroceryItems recipe1ingredient1 = new GroceryItems("Chicken Breasts", 1, "pound", "No");
        GroceryItems recipe1ingredient2 = new GroceryItems("Broccoli", 1, "head", "No");
        GroceryItems recipe1ingredient3 = new GroceryItems("Avocado Oil", 2, "tbsp.", "No");
        GroceryItems recipe1ingredient4 = new GroceryItems("Garlic Powder", 1, "tsp.", "No");
        GroceryItems recipe1ingredient5 = new GroceryItems("Salt", 1, "tsp.", "No");
        GroceryItems recipe1ingredient6 = new GroceryItems("Pepper", 1, "tsp.", "No");

        List<GroceryItems> recipe1ingredients = [recipe1ingredient1, recipe1ingredient2, recipe1ingredient3,
                                                recipe1ingredient4, recipe1ingredient5, recipe1ingredient6];

        Recipes recipe1 = new Recipes("Chicken & Broccoli Stir Fry", recipe1ingredients, "1. Cut chicken into 1 \" cubes.\n2. Cut broccoli into bite-sized florets\n"
                                        +"3. Heat avocado oil in saute pan on medium high heat\n4.Add chicken and broccoli to pan and cook until chicken is cooked through");

        // RECIPE 2: PASTA WITH HOMEMADE PESTO
        GroceryItems recipe2ingredient1 = new GroceryItems("Spaghetti", 1, "box", "No");
        GroceryItems recipe2ingredient2 = new GroceryItems("Basil", 2, "cups", "No");
        GroceryItems recipe2ingredient3 = new GroceryItems("Garlic", 4, "cloves", "No");
        GroceryItems recipe2ingredient4 = new GroceryItems("Pine Nuts", 1, "cup", "No");
        GroceryItems recipe2ingredient5 = new GroceryItems("Olive Oil", 0.5, "cup", "No");
        GroceryItems recipe2ingredient6 = new GroceryItems("Salt", 1, "tsp.", "No");

        List<GroceryItems> recipe2ingredients = [recipe2ingredient1, recipe2ingredient2, recipe2ingredient3,
                                                recipe2ingredient4, recipe2ingredient5, recipe2ingredient6];

        Recipes recipe2 = new Recipes("Pasta with Homemade Pesto", recipe2ingredients, "1. Bring a large pot of water to boil\n2. Add spaghetti and cook for length of time recommended on package\n"
                                        +"3. While spaghetti cooks, add all other ingredients to a blender or food processor and blend\n4. Drain pasta\n5. Stir pesto and pasta together and serve");

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

        Recipes recipe3 = new Recipes("Buffalo Chicken Stuffed Baked Potatoes", recipe3ingredients, "1. Pre-heat oven to 400 degrees\n"+
                                        "2. Wash potatoes and wrap each one in foil and place in oven\n"+
                                        "3. Let the potatoes cook for about 30 minutes and then start on the next steps\n"+
                                        "4. Put chicken in a large pot and fill it with water until the chicken is fully covered and then some\n"+
                                        "5. Put pot on the stove on medium high heat until the water boils \n"+
                                        "6. Once the water boils, turn the heat down to medium and cook until the chicken is cooked through"+
                                        "7. Once the chicken is cooked through, shred the chicken\n"+
                                        "8. Stir the buffalo and chicken to coat the chicken in sauce\n"+
                                        "9. When the potatoes are done, cut each potato down the center and"+
                                        "top with butter, salt, pepper, the shredded chicken coated in sauce, and ranch.");


        // RECIPE 4: GRILLED CHEESE SANDWICH

        GroceryItems recipe4ingredient1 = new GroceryItems("White Bread", 2, "slices", "No");
        GroceryItems recipe4ingredient2 = new GroceryItems("Butter", 0.5, "tbsp", "No");
        GroceryItems recipe4ingredient3 = new GroceryItems("Cheese", 2, "slices", "No");


        List<GroceryItems> recipe4ingredients = [recipe4ingredient1, recipe4ingredient2, recipe4ingredient3];

        Recipes recipe4 = new Recipes("Grilled Cheese Sandwich", recipe4ingredients, "1. Butter 1 side of each slice of bread\n"+
                                        "2. Place the buttered side of 1 slice of bread into a hot pan on medium heat\n"+
                                        "3. Add the cheese slices on top of the bread\n"+
                                        "4. Put the other slice of bread on top with the buttered side facing up\n"+
                                        "5. Cook until the bottom is golden brown\n"+
                                        "6. Flip sandwich over and cook until the other side is golden brown too");

        // RECIPE 5: GIRL DINNER

        GroceryItems recipe5ingredient1 = new GroceryItems("Salami", 3, "slices", "No");
        GroceryItems recipe5ingredient2 = new GroceryItems("Grapes", 1, "bunch", "No");
        GroceryItems recipe5ingredient3 = new GroceryItems("Crackers", 1, "cup", "No");
        GroceryItems recipe5ingredient4 = new GroceryItems("Goat Cheese", 3, "ounces", "No");
        GroceryItems recipe5ingredient5 = new GroceryItems("Turkey", 2, "slices", "No");
        GroceryItems recipe5ingredient6 = new GroceryItems("Apple", 1, "whole", "No");


        List<GroceryItems> recipe5ingredients = [recipe5ingredient1, recipe5ingredient2, recipe5ingredient3,
                                                recipe5ingredient4, recipe5ingredient5, recipe5ingredient6];

        Recipes recipe5 = new Recipes(" Board", recipe5ingredients, "1. Cut the apple into slices\n"+
                                        "2. Arrange ingredients on a plate");


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

        Recipes recipe6 = new Recipes("Turkey BLTA Sandwich", recipe6ingredients, "1. Slice the tomato and avacado\n"+
                                        "2. AssemCharcuterieble the sandwich");

        
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

        Recipes recipe7 = new Recipes("Caprese Salad", recipe7ingredients, "1. Cut the mozzarella into bite-sized pieces\n"+
                                        "2. Tear/roughly chop the basil\n"+
                                        "3. Add all inrgredients to a salad bowl and mix well");


    
    
            List<Recipes> newMealsToBeStored = [recipe1, recipe2, recipe3, recipe4, recipe5, recipe6, recipe7];
            string newMealsToBeStoredJson = JsonSerializer.Serialize<List<Recipes>>(newMealsToBeStored);
            File.WriteAllText(_filePath, newMealsToBeStoredJson);
        }
    }
    

