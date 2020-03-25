using System;
using System.Collections.Generic;
using UnityEngine;

public class RecipeBook
{
    public event Action<Recipe> OnRecipeAdded = delegate {  };
    public List<Recipe> Recipes { get; } = new List<Recipe>();

    public RecipeBook(RecipeDefinition[] recipeDefinitions) 
    {
        DirtyRecipeSetUp(recipeDefinitions);
    }
    public void AddRecipe(Recipe recipe)
    {
        Recipes.Add(recipe);
        OnRecipeAdded(recipe);
    }
    private void DirtyRecipeSetUp(RecipeDefinition[] recipeDefinitions)
    {
        foreach (var recipeDefinition in recipeDefinitions)
        {
            var recipe = recipeDefinition.GetRecipe();
            AddRecipe(recipe);
        }
    }
}