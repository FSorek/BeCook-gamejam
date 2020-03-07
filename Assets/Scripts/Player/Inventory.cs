using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private int _startWhite;
    [SerializeField] private int _startGreen;

    [SerializeField] private RecipeDefinition[] _recipeDefinition;
    
    private Dictionary<Resources, int> _resources = new Dictionary<Resources, int>();
    private List<Recipe> _recipes = new List<Recipe>();
    
    private void Awake()
    {
        DirtyResourcesSetUp();
        DirtyRecipeSetUp();
    }

    public void AddResources(Resources type, int amount)
    {
        if (amount <= 0)
        {
            Debug.LogWarning("add need to be positive");
            return;
        }

        _resources[type] += amount;
    }

    public void RemoveResources(Resources type, int amount)
    {
        if (amount <= 0)
        {
            Debug.LogWarning("add need to be positive");
            return;
        }

        if (_resources[type] < amount)
        {
            Debug.LogWarning("you try to remove too much");
        }
        
        _resources[type] -= amount;
    }

    private void DirtyRecipeSetUp()
    {
        foreach (var recipeDefinition in _recipeDefinition)
        {
            var recipe = recipeDefinition.GetRecipe();
            _recipes.Add(recipe);
            
            Debug.Log(recipe.Name);
        }
    }

    private void DirtyResourcesSetUp()
    {
        _resources.Add(Resources.White, _startWhite);
        _resources.Add(Resources.Green, _startGreen);
    }
}