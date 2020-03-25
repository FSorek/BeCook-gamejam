using UnityEngine;

public class Adventurer
{
    public readonly string Name;
    public readonly Sprite Sprite ;

    public readonly AdventurerInventory AdventurerInventory;
    public Adventurer(string name,Sprite sprite)
    {
        Name = name;
        Sprite = sprite;
        AdventurerInventory=new AdventurerInventory();
    }
}