using System;
using UnityEngine;

public class UIRecipeBook : MonoBehaviour
{
    [SerializeField] private RectTransform _bookContent;
    [SerializeField] private UIRecipe _uiRecipePrefab;
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
        UIRecipe uiRecipe = Instantiate(_uiRecipePrefab, _bookContent);
        uiRecipe.Initialize(recipe);
    }
}
