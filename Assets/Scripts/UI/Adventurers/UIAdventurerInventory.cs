using System;
using System.Collections.Generic;
using Items;
using UnityEngine;
using UnityEngine.UI;

public class UIAdventurerInventory : MonoBehaviour
{
    [SerializeField] private List<UIAdventureSlotByType> _uiAdventureSlots;
    [SerializeField] private Image _adventurerImage;

    private Dictionary<SlotType, UIAdventurerInventorySlot> _uiAdventureSlotsD;
    private AdventurerInventory _adventurerInventory;
    private InventoryController _inventoryController;
    
    public AdventurerInventory AdventurerInventory => _adventurerInventory;

    public void Initialize(Adventurer adventurer)
    {
        _inventoryController = FindObjectOfType<Player>().InventoryController;
        _adventurerInventory = adventurer.AdventurerInventory;
        _adventurerImage.sprite = adventurer.Sprite;
        
        _adventurerInventory.OnAddItemD += CreateUIItemInSlot;
        _adventurerInventory.OnRemoveItem += DestroyUIItemAdventurerAndClearSlot;
        
        SetUpDictionaryUIAdventurerSlots();

        gameObject.SetActive(false);
    }

    private void SetUpDictionaryUIAdventurerSlots()
    {
        _uiAdventureSlotsD = new Dictionary<SlotType, UIAdventurerInventorySlot>();

        foreach (var slot in _uiAdventureSlots)
        {
            _uiAdventureSlotsD.Add(slot.SlotType, slot.UIAdventurerInventorySlot);
            slot.UIAdventurerInventorySlot.SlotTypeD = slot.SlotType;
        }
    }

    private void CreateUIItemInSlot(SlotType slotType, Item item)
    {
        _uiAdventureSlotsD[slotType].CreateUIItem(item);
    }

    private void DestroyUIItemAdventurerAndClearSlot(Item item)
    {
        foreach (var slot in _uiAdventureSlotsD)
        {
            if (slot.Value.IsEmpty) continue;

            if (slot.Value.ItemInSlot == item)
            {
                slot.Value.RemoveUIItem();
            }
        }
    }


    public void OnUIItemDrop(UIAdventurerInventorySlot slotDropOn, UIItem uiItemDrop)
    {
        var itemDrop = uiItemDrop.Item;
        bool slotDropOnWasEmpty = slotDropOn.IsEmpty;

        var slotDropOnType = slotDropOn.SlotTypeD;

        bool goodType = _adventurerInventory.GetItemType(slotDropOnType) == itemDrop.ItemType;


        if (slotDropOnWasEmpty && goodType)
        {
            _inventoryController.EquipItem(_adventurerInventory,slotDropOnType,itemDrop);
        }
        else if (slotDropOnWasEmpty == false && goodType)
        {

            _inventoryController.SwitchItemInventoryToAdventurer(_adventurerInventory,slotDropOnType,itemDrop);
        }
    }

    private void OnDestroy()
    {
        _adventurerInventory.OnAddItemD -= CreateUIItemInSlot;
        _adventurerInventory.OnRemoveItem += DestroyUIItemAdventurerAndClearSlot;
    }
}

[Serializable]
public struct UIAdventureSlotByType
{
    public SlotType SlotType;
    public UIAdventurerInventorySlot UIAdventurerInventorySlot;
}