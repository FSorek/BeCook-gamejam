using System;
using UnityEngine;

public class UIRecipeBook : MonoBehaviour
{
    [SerializeField] private RectTransform _bookContent;
    [SerializeField] private GameObject _uiRecipePrefab;
    private void Start()
    {
        var player = FindObjectOfType<Player>();
        player.RecipeBook.OnRecipeAdded += CreateUIRecipe;

        foreach (var recipe in player.RecipeBook.Recipes)
        {
            CreateUIRecipe(recipe);
        }
    }

    private void CreateUIRecipe(Recipe recipe)
    {
        var uiRecipe = Instantiate(_uiRecipePrefab, _bookContent);
        
    }
}
