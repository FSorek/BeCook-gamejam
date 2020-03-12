﻿using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIRecipe : MonoBehaviour, ISelectHandler
{
    public static Action<Recipe> OnRecipeSelected = delegate {  };
    
    [SerializeField] private TMP_Text _nameText;
    [SerializeField] private UIResource _uiResourcePrefab;
    [SerializeField] private Transform _neededResourcesParent;
    [SerializeField] private GameObject _cantCraftImage;

    private Recipe _assignedRecipe;

    public void OnSelect(BaseEventData eventData)
    {
        OnRecipeSelected(_assignedRecipe);
        Debug.Log($"Selected {_assignedRecipe?.Name}");
    }

    public void Initialize(Recipe recipe)
    {
        _assignedRecipe = recipe;

        _nameText.text = recipe.Name;
        foreach (var resource in recipe.NeededResources)
        {
            UIResource resourceInstance = Instantiate(_uiResourcePrefab, _neededResourcesParent);
            resourceInstance.Initialize(resource.Key, resource.Value);
        }
    }

    public void RefreshCanCraftState(ResourceBag resourceBag)
    {
        var canCraft = _assignedRecipe.CanCraft(resourceBag.CurrentResources);

        _cantCraftImage.SetActive(!canCraft);
    }
}
