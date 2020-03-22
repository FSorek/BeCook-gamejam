using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIRecipe : MonoBehaviour, ISelectHandler
{
    public static Action<Recipe> OnRecipeSelected = delegate {  };
    
    [SerializeField] private TMP_Text _nameText;
    [SerializeField] private UIResource _uiResourcePrefab;
    [SerializeField] private Transform _neededResourcesParent;
    [SerializeField] private Image _image;
    [SerializeField] private GameObject _cantCraftImage;
    

    public Recipe AssignedRecipe { get; private set; }

    public void OnSelect(BaseEventData eventData)
    {
        OnRecipeSelected(AssignedRecipe);
        Debug.Log($"Selected {AssignedRecipe?.Name}");
    }

    public void Initialize(Recipe recipe)
    {
        AssignedRecipe = recipe;

        _nameText.text = recipe.Name;
        _image.sprite = recipe.ItemDefinition.Sprite;
        foreach (var resource in recipe.NeededResources)
        {
            UIResource resourceInstance = Instantiate(_uiResourcePrefab, _neededResourcesParent);
            resourceInstance.Initialize(resource.Key, resource.Value);
        }
    }

    public void RefreshCanCraftState(ResourceBag resourceBag)
    {
        var canCraft = AssignedRecipe.CanCraft(resourceBag.CurrentResources);

        _cantCraftImage.SetActive(!canCraft);
    }
}
