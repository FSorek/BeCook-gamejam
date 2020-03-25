using System.Collections.Generic;
using UnityEngine;

public class Adventurers : MonoBehaviour
{
    [SerializeField] private List<AdventurersDefinition> _adventurersDefinitions;
    private List<Adventurer> _adventurers;

    public List<Adventurer> AdventurersList => _adventurers;

    private void Awake()
    {
        CreateAdventurers();
    }

    private void CreateAdventurers()
    {
        _adventurers=new List<Adventurer>();
        foreach (var adventurersDefinition in _adventurersDefinitions)
        {
            var newAdventurer = adventurersDefinition.GetAdventurer();
            _adventurers.Add(newAdventurer);
        }
    }
}