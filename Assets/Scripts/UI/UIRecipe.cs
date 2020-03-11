using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIRecipe : MonoBehaviour, ISelectHandler
{
    public static Action<Recipe> OnRecipeSelected = delegate {  };
    
    [SerializeField] private TMP_Text _nameText;
    [SerializeField] private UIResource _uiResourcePrefab;
    [SerializeField] private Transform _neededResourcesParent;

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
}
