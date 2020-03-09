using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIOpenCloseInventoryPanel : MonoBehaviour
{
    [SerializeField] private GameObject _inventoryPanel;

    private bool _panelIsEnable => _inventoryPanel.activeSelf;
    
    public void OpenCloseInventoryPanel()
    {
        _inventoryPanel.gameObject.SetActive(!_panelIsEnable);
    }
}
