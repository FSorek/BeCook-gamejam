using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIRecipe : MonoBehaviour, ISelectHandler
{
    public static Action<Recipe> OnRecipeSelected = delegate {  };

    private Recipe assignedRecipe;

    public void OnSelect(BaseEventData eventData)
    {
        OnRecipeSelected(assignedRecipe);
        Debug.Log("Selected a recipe.");
    }
}
