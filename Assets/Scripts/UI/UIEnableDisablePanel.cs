using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEnableDisablePanel : MonoBehaviour
{
    [SerializeField] private GameObject _panel;

    private bool _panelIsEnable => _panel.activeSelf;
    
    public void EnableDisablePanel()
    {
        _panel.gameObject.SetActive(!_panelIsEnable);
    }
}
