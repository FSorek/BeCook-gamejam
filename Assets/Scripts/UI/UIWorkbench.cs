using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWorkbench : MonoBehaviour,IOpenCloseUIPanel
{
    [SerializeField] private GameObject _uiWorkbenchPanel;

    [SerializeField]private Transform _activeUiRecipeParent;
    [SerializeField] private UIRecipe _uiRecipePrefab;
    private UIRecipe _activeUiRecipe;

    private void Awake()
    {
        UIRecipe.OnRecipeSelected += ChangeActiveRecipe;
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
    
    public void OpenUIPanel()
    {
        _uiWorkbenchPanel.SetActive(true);
    }

    public void CloseUIPanel()
    {
        _uiWorkbenchPanel.SetActive(false);

        if (_activeUiRecipe != null)
        {
            Destroy(_activeUiRecipe.gameObject);
            _activeUiRecipe = null;
        }
    }
}
