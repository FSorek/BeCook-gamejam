using System;

namespace Items
{
    [Serializable]
    public class Item
    {
        public string Name { get; }
        public int Durability { get; }

        public Item(string name, int durability)
        {
            Name = name;
            Durability = durability;
        }
    }
}