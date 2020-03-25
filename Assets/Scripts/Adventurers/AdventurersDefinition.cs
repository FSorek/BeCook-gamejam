using UnityEngine;

[CreateAssetMenu(fileName = "Adventurer Definition")]
public class AdventurersDefinition : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _sprite;

    public Adventurer GetAdventurer()
    {
        var adventurer = new Adventurer(_name,_sprite);
        return adventurer;
    }
}