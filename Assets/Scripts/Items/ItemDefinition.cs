using UnityEngine;
using UnityEngine.UI;

namespace Items
{
    [CreateAssetMenu(fileName = "Item Definition")]
    public class ItemDefinition : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private int _durability;
        [SerializeField] private ItemType _itemType;
        [SerializeField] private Sprite _sprite;

        public Sprite Sprite => _sprite;
        public Item GetItem()
        {
            var item = new Item(_name,_sprite,_itemType ,_durability);
            return item;
        }
    }
}