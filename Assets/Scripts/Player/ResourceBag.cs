using System;
using System.Collections.Generic;
using UnityEngine;

public class ResourceBag
{
    public event Action OnResourcesChanged; 
    public Dictionary<ResourceType, Resource> CurrentResources { get; } = new Dictionary<ResourceType, Resource>();

    public ResourceBag(ResourceDefinition[] resourceDefinitions)
    {
        foreach (var resourceDefinition in resourceDefinitions)
        {
            var newResource = new Resource(resourceDefinition);
            AddResources(newResource, resourceDefinition.StartingAmount);
        }
    }
    public void AddResources(Resource resource, int amount)
    {
        if (amount <= 0)
        {
            Debug.LogWarning("add need to be positive");
            return;
        }
        
        if(!CurrentResources.ContainsKey(resource.Type))
        {
            CurrentResources.Add(resource.Type, resource);
        }
        CurrentResources[resource.Type].Amount += amount;
        OnResourcesChanged?.Invoke();
    }

    public void RemoveResources(ResourceType type, int amount)
    {
        if (amount <= 0)
        {
            Debug.LogWarning("add need to be positive");
            return;
        }

        if (CurrentResources[type].Amount < amount)
        {
            Debug.LogWarning("you try to remove too much");
        }
        
        CurrentResources[type].Amount -= amount;
        OnResourcesChanged?.Invoke();
    }

    public void RemoveResources(Dictionary<ResourceDefinition, int> resources)
    {
        foreach (var resource in resources)
        {
            if (resource.Value <= 0)
            {
                Debug.LogWarning("add need to be positive");
                return;
            }

            CurrentResources[resource.Key.Type].Amount -= resource.Value;
        }
        OnResourcesChanged?.Invoke();
    }
}