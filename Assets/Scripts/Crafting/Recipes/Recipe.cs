using System.Collections.Generic;
using Items;

public class Recipe
{
    public Dictionary<Resources, int> NeededResources { get; }
    public string Name { get; }
    public ItemDefinition ItemDefinition { get; }
    
    public Recipe(Dictionary<Resources, int> neededResources, string name, ItemDefinition itemDefinition)
    {
        NeededResources = neededResources;
        Name = name;
        ItemDefinition = itemDefinition;
    }

    public bool CanCraft(Dictionary<Resources, int> availableResources)
    {
        foreach (var neededResource in NeededResources)
        {
            if (availableResources.ContainsKey(neededResource.Key))
            {
                if (neededResource.Value > availableResources[neededResource.Key])
                {
                    return false;
                }
            }
        }

        return true;
    }
}