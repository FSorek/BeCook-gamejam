using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Items
{
    public class TestStatObject : MonoBehaviour, IHaveStats
    {
        private Dictionary<StatType, Stat> _stats = new Dictionary<StatType, Stat>();
        [SerializeField] private List<ItemDefinition> _items;
        private readonly List<Item> _heldItems = new List<Item>();

        private void Awake()
        {
            _stats.Add(StatType.Armor, new Stat(10));
            _stats.Add(StatType.Damage, new Stat(10));
            _stats.Add(StatType.Durability, new Stat(10));
            _stats.Add(StatType.Health, new Stat(10));
            _stats.Add(StatType.MagicalEffectiveness, new Stat(10));
            _stats.Add(StatType.MagicalProc, new Stat(10));
            
            foreach (var item in _items)
            {
                _heldItems.Add(item.GetItem());
            }
        }

        private void Update()
        {
            foreach (var stat in _stats)
            {
                Debug.Log($"{stat.Key} = {stat.Value.EffectiveValue}");
            }
        }

        [ContextMenu(nameof(UnequipAll))]
        public void UnequipAll()
        {
            foreach (var heldItem in _heldItems)
            {
                heldItem.Unequip(this);
            }
        }
        
        [ContextMenu(nameof(EquipAll))]
        public void EquipAll()
        {
            foreach (var heldItem in _heldItems)
            {
                heldItem.Equip(this);
            }
        }
        [ContextMenu(nameof(UpdateItems))]
        public void UpdateItems()
        {
            _heldItems.Clear();
            foreach (var item in _items)
            {
                _heldItems.Add(item.GetItem());
            }
        }

        public Stat GetStat(StatType stat)
        {
            return _stats.ContainsKey(stat) ? _stats[stat] : null;
        }
    }
}