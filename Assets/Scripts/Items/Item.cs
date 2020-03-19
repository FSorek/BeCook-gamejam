using System;
using UnityEngine;
using UnityEngine.UI;

namespace Items
{
    [Serializable]
    public class Item
    {
        public string Name { get; }
        
        public Sprite Sprite { get; }
        
        public ItemType ItemType { get; }
        public int Durability { get; }

        public Item(string name,Sprite sprite,ItemType itemType, int durability)
        {
            Name = name;
            Sprite = sprite;
            ItemType = itemType;
            Durability = durability;
        }
    }
}