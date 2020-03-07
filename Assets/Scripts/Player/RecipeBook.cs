using System.Collections.Generic;
using UnityEngine;

public class RecipeBook
{
    public List<Recipe> Recipes { get; } = new List<Recipe>();

    public RecipeBook(RecipeDefinition[] recipeDefinitions) 
    {
        DirtyRecipeSetUp(recipeDefinitions);
    }

    public void AddRecipe(Recipe recipe)
    {
        Recipes.Add(recipe);
    }
    private void DirtyRecipeSetUp(RecipeDefinition[] recipeDefinitions)
    {
        foreach (var recipeDefinition in recipeDefinitions)
        {
            var recipe = recipeDefinition.GetRecipe();
            Recipes.Add(recipe);
            
            Debug.Log(recipe.Name);
        }
    }
}