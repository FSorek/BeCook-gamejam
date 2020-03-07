using System.Collections.Generic;
using UnityEngine;

public class ResourceBag
{
    public Dictionary<Resources, int> CurrentResources { get; } = new Dictionary<Resources, int>();

    public void AddResources(Resources type, int amount)
    {
        if (amount <= 0)
        {
            Debug.LogWarning("add need to be positive");
            return;
        }
        if(!CurrentResources.ContainsKey(type))
        {
            CurrentResources.Add(type, amount);
            return;
        }
        CurrentResources[type] += amount;
    }

    public void RemoveResources(Resources type, int amount)
    {
        if (amount <= 0)
        {
            Debug.LogWarning("add need to be positive");
            return;
        }

        if (CurrentResources[type] < amount)
        {
            Debug.LogWarning("you try to remove too much");
        }
        
        CurrentResources[type] -= amount;
    }
}