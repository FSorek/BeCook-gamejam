using System;
using System.Collections.Generic;
using Items;
using UnityEngine;

[CreateAssetMenu(menuName = "RecipeDefinition")]
public class RecipeDefinition : ScriptableObject
{
    [SerializeField] private List<ResourceAmount> _resourceAmounts;
    [SerializeField] private string _name;
    [SerializeField] private ItemDefinition _itemDefinition;
    
    public Recipe GetRecipe()
    {
        var dictionaryRecipe = new Dictionary<Resources, int>();
        
        foreach (var resourceAmount in _resourceAmounts)
        {
            dictionaryRecipe.Add(resourceAmount.Resource,resourceAmount.Amount);
        }
        
        var recipe = new Recipe(dictionaryRecipe, _name, _itemDefinition);
        return recipe;
    }
}