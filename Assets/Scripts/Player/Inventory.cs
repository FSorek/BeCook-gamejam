using System.Collections;
using System.Collections.Generic;
using Items;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private RecipeDefinition[] _recipeDefinition;
    
    public List<Recipe> Recipes { get; private set; } = new List<Recipe>();
    private List<Item> _items = new List<Item>();
    
    private void Awake()
    {
        DirtyRecipeSetUp();
    }

    private void DirtyRecipeSetUp()
    {
        foreach (var recipeDefinition in _recipeDefinition)
        {
            var recipe = recipeDefinition.GetRecipe();
            Recipes.Add(recipe);
            
            Debug.Log(recipe.Name);
        }
    }

    public void AddItem(Item item)
    {
        _items.Add(item);
    }
}