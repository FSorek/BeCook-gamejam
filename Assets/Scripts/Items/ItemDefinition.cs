using UnityEngine;

namespace Items
{
    [CreateAssetMenu(fileName = "Item Definition")]
    public class ItemDefinition : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private int _durability;

        public Item GetItem()
        {
            var item = new Item(_name, _durability);
            return item;
        }
    }
}