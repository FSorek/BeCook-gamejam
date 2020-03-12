using System;
using System.Collections.Generic;
using UnityEngine;

public class UIRecipeBook : MonoBehaviour,IOpenCloseUIPanel
{
    [SerializeField] private RectTransform _bookContent;
    [SerializeField] private UIRecipe _uiRecipePrefab;
    [SerializeField] private GameObject _recipeBookPanel;
    
    private RecipeBook _recipeBook;
    private ResourceBag _resourceBag;

    private List<UIRecipe> _uiRecipes=new List<UIRecipe>();
    
    private void Start()
    {
        var player = FindObjectOfType<Player>();
        _recipeBook = player.RecipeBook;
        _resourceBag = player.ResourceBag;
        
        _recipeBook.OnRecipeAdded += CreateUIRecipe;
        _resourceBag.OnResourcesChanged += RefreshRecipesCanCraftState;

        foreach (var recipe in player.RecipeBook.Recipes)
        {
            CreateUIRecipe(recipe);
        }
    }
    private void OnDestroy()
    {
        _recipeBook.OnRecipeAdded -= CreateUIRecipe;
        _resourceBag.OnResourcesChanged += RefreshRecipesCanCraftState;
    }

    private void CreateUIRecipe(Recipe recipe)
    {
        UIRecipe uiRecipe = Instantiate(_uiRecipePrefab, _bookContent);
        uiRecipe.Initialize(recipe);
        _uiRecipes.Add(uiRecipe);
    }

    private void RefreshRecipesCanCraftState()
    {
        foreach (var uiRecipe in _uiRecipes)
        {
            uiRecipe.RefreshCanCraftState(_resourceBag);
        }
    }

    public void OpenUIPanel()
    {
        _recipeBookPanel.SetActive(true);
    }

    public void CloseUIPanel()
    {
        _recipeBookPanel.SetActive(false);
    }
}
