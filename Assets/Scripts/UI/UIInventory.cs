using System;
using System.Collections;
using System.Collections.Generic;
using Items;
using UnityEngine;

public class UIInventory : MonoBehaviour,IOpenCloseUIPanel
{
    [SerializeField]private UIInventorySlot[] _slots;
    [SerializeField] private GameObject _inventoryPanel;
    
    private Inventory _inventory;
    
    private void Start()//Inventory is create on player Awake
    {
        _inventory = FindObjectOfType<Player>().Inventory;
        
        _inventory.OnAddItem += AddItemToAvailableSlot;
    }

    private void OnDestroy()
    {
        _inventory.OnAddItem -= AddItemToAvailableSlot;
    }
    
    private void AddItemToAvailableSlot(Item item)
    {
        var findAvailableSlot=false;

        foreach (var slot in _slots)
        {
            if (!slot.IsEmpty) continue;
            
            slot.SetItemAndRefreshUI(item);
            findAvailableSlot = true;
            break;
        }
        
        if(findAvailableSlot==false)
            Debug.LogWarning("need more slot",this);
        
    }

    public void OpenUIPanel()
    {
        _inventoryPanel.SetActive(true);
    }

    public void CloseUIPanel()
    {
        _inventoryPanel.SetActive(false);
    }
}