using System;
using UnityEngine;

public class Workbench : MonoBehaviour, IInteractable
{
   // private Player _player;

    private UIWorkbench _uiWorkbench;
    private UIRecipeBook _uiRecipeBook;
    private UIInventory _uiInventory;

    private bool _craftingPanelsWereOpened;
    public void Use()
    {
        //Cant do that on awake because ui scene are not loaded when awake is call
        TryToInitializeFields();
        
        if (_craftingPanelsWereOpened == false)
        {
            OpenCraftingPanels();
        }
        else
        {
            CloseCraftingPanels();
        }
        
    }

    private void CloseCraftingPanels()
    {
        _uiWorkbench.CloseUIPanel();
        _uiRecipeBook.CloseUIPanel();
        _uiInventory.CloseUIPanel();
        _craftingPanelsWereOpened = false;
    }

    private void OpenCraftingPanels()
    {
        _uiWorkbench.OpenUIPanel();
        _uiRecipeBook.OpenUIPanel();
        _uiInventory.OpenUIPanel();
        _craftingPanelsWereOpened = true;
    }

    private void TryToInitializeFields()
    {
        if (_uiWorkbench == null || _uiRecipeBook == null || _uiInventory == null)
        {
            _uiWorkbench = FindObjectOfType<UIWorkbench>();
            _uiRecipeBook = FindObjectOfType<UIRecipeBook>();
            _uiInventory = FindObjectOfType<UIInventory>();
        }
    }
    
//    private void Awake()
//    {
//        _player = FindObjectOfType<Player>();
//    }

//    public void Use()
//    {
//        Debug.Log($"Used {gameObject.name}.");
//        var recipe = _player.RecipeBook.Recipes[0];
//
//        var canCraft = recipe.CanCraft(_player.ResourceBag.CurrentResources);
//
//        if (canCraft)
//        {
//            foreach (var neededResource in recipe.NeededResources)
//            {
//                _player.ResourceBag.RemoveResources(neededResource.Key, neededResource.Value);
//            }
//
//            _player.Inventory.AddItem(recipe.ItemDefinition.GetItem());
//        }
//    }

}