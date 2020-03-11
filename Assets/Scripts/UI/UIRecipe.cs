using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIRecipe : MonoBehaviour, ISelectHandler
{
    [SerializeField] private TMP_Text _nameText;
    public static Action<Recipe> OnRecipeSelected = delegate {  };

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
    }
}
