using System;
using System.Collections.Generic;
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
        public List<StatModifier> StatModifiers { get; }
        
        public Item(string name, Sprite sprite, int durability, ItemType itemType, List<StatModifier> statModifiers)
        {
            Name = name;
            Sprite = sprite;
            ItemType = itemType;
            Durability = durability;
            ItemType = itemType;
            StatModifiers = statModifiers;
        }

        public void Equip(IHaveStats user)
        {
            foreach (var statModifier in StatModifiers)
            {
                var userStat = user.GetStat(statModifier.StatToModify);
                userStat?.AddModifier(statModifier);
            }
        }

        public void Unequip(IHaveStats user)
        {
            foreach (var statModifier in StatModifiers)
            {
                var userStat = user.GetStat(statModifier.StatToModify);
                userStat?.RemoveModifier(statModifier);
            }
        }
    }
}