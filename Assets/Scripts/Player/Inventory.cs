using System;
using System.Collections;
using System.Collections.Generic;
using Items;
using UnityEngine;

public class Inventory
{
    private List<Item> _items = new List<Item>();

    public event Action<Item> OnAddItem;
    public event Action<Item> OnRemoveItem;
    public bool IsFull => (_items.Count >= 25);
    public void AddItem(Item item)
    {
        _items.Add(item);
        OnAddItem?.Invoke(item);
    }

    public void RemoveItem(Item item)
    {
        if (_items.Contains(item))
        {
            _items.Remove(item);
            OnRemoveItem?.Invoke(item);
        }
            
    }

    public bool ContainItem(Item item)
    {
        return _items.Contains(item);
    }
}
