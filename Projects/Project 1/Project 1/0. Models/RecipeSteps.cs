namespace Project1.Models;

public class RecipeSteps
{
    public Guid recipeStepId {get; set;}
    public int recipeStepSequence {get; set;}
    public string? recipeStepDescription {get; set;}

    public RecipeSteps(){} // Added this to fix the issue with the json deserializer

    public RecipeSteps (int _recipeStepSequence, string _recipeStepDescription)
    {
        recipeStepId = Guid.NewGuid();
        recipeStepSequence = _recipeStepSequence;
        recipeStepDescription = _recipeStepDescription;
    }

       

    
}