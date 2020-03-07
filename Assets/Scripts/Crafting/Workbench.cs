using System;
using UnityEngine;

public class Workbench : MonoBehaviour, IInteractable
{
    private Player _player;

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
    }

    public void Use()
    {
        Debug.Log($"Used {gameObject.name}.");
        var recipe = _player.Inventory.Recipes[0];

        var canCraft = recipe.CanCraft(_player.ResourceBag.CurrentResources);

        if (canCraft)
        {
            foreach (var neededResource in recipe.NeededResources)
            {
                _player.ResourceBag.RemoveResources(neededResource.Key, neededResource.Value);
            }

            _player.Inventory.AddItem(recipe.ItemDefinition.GetItem());
        }
    }
}