using System;
using System.Collections;
using System.Collections.Generic;
using Items;
using UnityEngine;

public class UIInventory : OpenClosePanel
{
    [SerializeField]private UIInventorySlot[] _slots;
    
    private Inventory _inventory;
    private InventoryController _inventoryController;
    
    private void Start()//Inventory is create on player Awake
    {
        var player = FindObjectOfType<Player>();
        _inventory = player.Inventory;
        _inventoryController = player.InventoryController;
        _inventory.OnAddItem += AddItemToAvailableSlot;
        _inventory.OnRemoveItem += OnItemRemove;
    }

    private void OnDestroy()
    {
        _inventory.OnAddItem -= AddItemToAvailableSlot;
        _inventory.OnRemoveItem -= OnItemRemove;
    }
    
    private void AddItemToAvailableSlot(Item item)
    {
        var findAvailableSlot=false;

        foreach (var slot in _slots)
        {
            if (!slot.IsEmpty) continue;
            
            slot.CreateAndSetUIItem(item);
            findAvailableSlot = true;
            break;
        }
        
        if(findAvailableSlot==false)
            Debug.LogWarning("need more slot",this);
    }

    private void OnItemRemove(Item item)
    {
        foreach (var slot in _slots)
        {
            if(slot.IsEmpty)
                continue;
            if (slot.CurrentUIItem.Item == item)
            {
                slot.RemoveUIItem();
            }
        }
    }
    
    public void OnUIItemDrop(UIInventorySlot slot, UIItem uiItemDrop)
    { 
        bool slotWasEmpty = slot.IsEmpty;

        var oldSlot = uiItemDrop.CurrentUIInventorySlot;
        var itemDrop = uiItemDrop.Item;
        
        if (slotWasEmpty)
        {
            oldSlot.Clear();
            Destroy(uiItemDrop.gameObject);
            
            slot.CreateAndSetUIItem(itemDrop);
        }
        else
        {
            Item itemInSlot = slot.CurrentUIItem.Item;
            UIItem uiItemSlot = slot.CurrentUIItem;
            
            Destroy(uiItemDrop.gameObject);
            Destroy(uiItemSlot.gameObject);
            
            slot.CreateAndSetUIItem(itemDrop);
            oldSlot.CreateAndSetUIItem(itemInSlot);
        }
    }

    public void OnUIItemAdventurerDrop(UIInventorySlot slot, UIItemAdventurer uiItemAdventurer)
    {
        var itemDrop = uiItemAdventurer.Item;
        bool slotWasEmpty = slot.IsEmpty;

        var adventurerInventory = uiItemAdventurer.AdventurerInventory;
        
        if (slotWasEmpty)
        {
            _inventoryController.UnEquipItem(adventurerInventory,itemDrop);
            return;
        }

        Item itemInSlot = slot.CurrentUIItem.Item;
        
        bool canSwitchItems=(itemDrop.ItemType==itemInSlot.ItemType);

        if (canSwitchItems)
        {
            var slotType = uiItemAdventurer.CurrentUIInventorySlot.SlotTypeD;
            _inventoryController.SwitchItemInventoryToAdventurer(adventurerInventory,slotType,itemInSlot);
            return;
        }
        

        if (_inventory.IsFull==false)
        {
            _inventoryController.UnEquipItem(adventurerInventory,itemDrop);
        }
    }
}