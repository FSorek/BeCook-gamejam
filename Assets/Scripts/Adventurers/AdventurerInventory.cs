using System;
using System.Collections.Generic;
using Items;
using UnityEngine;

public class AdventurerInventory
{
    public event Action<SlotType,Item> OnAddItemD;
    public event Action<Item> OnRemoveItem;

    private Dictionary<SlotType, AdventurerSlot> _adventurerSlots;
    public AdventurerInventory()
    {
        _adventurerSlots = new Dictionary<SlotType, AdventurerSlot>
        {
            {SlotType.Weapon, new AdventurerSlot(ItemType.Weapon)},
            {SlotType.Armor, new AdventurerSlot(ItemType.Armor)},
            {SlotType.Relic1, new AdventurerSlot(ItemType.Relic)},
            {SlotType.Relic2, new AdventurerSlot(ItemType.Relic)},
            {SlotType.Relic3, new AdventurerSlot(ItemType.Relic)}
        };
    }

    public void EquipItem(SlotType slotType, Item item)
    {
        AdventurerSlot adventurerSlot = _adventurerSlots[slotType];

        if (adventurerSlot.ItemType == item.ItemType)
        {
            adventurerSlot.SetItem(item);
            OnAddItemD?.Invoke(slotType,item);
        }
    }

    public void UnEquipItem(Item item)
    {
        foreach (var adventurerSlot in _adventurerSlots)
        {
            if (adventurerSlot.Value.Item == item)
            {
                adventurerSlot.Value.SetItem(null);
                OnRemoveItem?.Invoke(item);
                break;
            }
        }
    }
    
    public ItemType GetItemType(SlotType slotType)
    {
        return _adventurerSlots[slotType].ItemType;
    }

//    public List<Item> GetItems()
//    {
//        var items = new List<Item>();
//        foreach (var adventurerSlot in _adventurerSlots)
//        {
//            if (adventurerSlot.Value != null)
//                items.Add(adventurerSlot.Value.Item);
//        }
//
//        return items;
//    }



    public bool SlotIsEmpty(SlotType slotType)
    {
        return _adventurerSlots[slotType].Item == null;
    }

    public Item GetItem(SlotType slotType)
    {
        return _adventurerSlots[slotType].Item;
    }

    public bool ContainItem(Item item)
    {
        foreach (var slot in _adventurerSlots)
        {
            if (slot.Value.Item == item)
                return true;
        }

        return false;
    }
}

public class AdventurerSlot
{
    public readonly ItemType ItemType;
    public Item Item { get; private set; }
    
    public AdventurerSlot(ItemType itemType)
    {
        ItemType = itemType;
    }

    public void SetItem(Item item)
    {
        Item = item;
    }
}