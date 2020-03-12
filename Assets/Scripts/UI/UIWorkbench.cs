using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWorkbench : OpenClosePanel
{
    [SerializeField] private GameObject _uiWorkbenchPanel;
    [SerializeField] private Transform _activeUiRecipeParent;
    [SerializeField] private UIRecipe _uiRecipePrefab;

    private Player _player;
    private UIRecipe _activeUiRecipe;

    private void Awake()
    {
        UIRecipe.OnRecipeSelected += ChangeActiveRecipe;
        _player = FindObjectOfType<Player>();
    }
    
    private void OnDestroy()
    {
        UIRecipe.OnRecipeSelected += ChangeActiveRecipe;
    }

    private void ChangeActiveRecipe(Recipe newActiveRecipe)
    {
        if(_activeUiRecipe!=null)
            Destroy(_activeUiRecipe.gameObject);
        
        _activeUiRecipe = Instantiate(_uiRecipePrefab, _activeUiRecipeParent);
        _activeUiRecipe.Initialize(newActiveRecipe);
    }

    public void Craft()
    {
        if (_activeUiRecipe != null)
        {
            bool canCraft = _activeUiRecipe.AssignedRecipe.CanCraft(_player.ResourceBag.CurrentResources);
            if(!canCraft)
                return;

            _player.ResourceBag.RemoveResources(_activeUiRecipe.AssignedRecipe.NeededResources);
            var itemToCraft = _activeUiRecipe.AssignedRecipe.ItemDefinition.GetItem();
            
            _player.Inventory.AddItem(itemToCraft);
        }
    }
}
