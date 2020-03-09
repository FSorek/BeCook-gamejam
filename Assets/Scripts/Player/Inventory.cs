using System;
using System.Collections;
using System.Collections.Generic;
using Items;
using UnityEngine;

public class Inventory
{
    private List<Item> _items = new List<Item>();

    public event Action<Item> OnAddItem;
    public List<Item> Items => _items;
    
    public void AddItem(Item item)
    {
        _items.Add(item);
        OnAddItem?.Invoke(item);
    }
}