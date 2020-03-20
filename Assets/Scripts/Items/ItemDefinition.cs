using System.Collections.Generic;
using UnityEngine;

namespace Items
{
    [CreateAssetMenu(fileName = "Item Definition")]
    public class ItemDefinition : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private int _durability;
        [SerializeField] private ItemType _itemType;
        [SerializeField] private Sprite _sprite;
        [SerializeField] private List<StatModifier> _statModifiers;

        public Item GetItem()
        {
            var item = new Item(_name,_sprite, _durability, _itemType, _statModifiers);
            return item;
        }
    }
}