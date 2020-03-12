using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWorkbench : MonoBehaviour,IOpenCloseUIPanel
{
    [SerializeField] private GameObject _uiWorkbenchPanel;
    public void OpenUIPanel()
    {
        _uiWorkbenchPanel.SetActive(true);
    }

    public void CloseUIPanel()
    {
        _uiWorkbenchPanel.SetActive(false);
    }
}
