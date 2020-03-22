using System.Collections.Generic;
using Items;

public class Recipe
{
    public Dictionary<ResourceDefinition, int> NeededResources { get; }
    public string Name { get; }
    public ItemDefinition ItemDefinition { get; }
    
    public Recipe(Dictionary<ResourceDefinition, int> neededResources, string name, ItemDefinition itemDefinition)
    {
        NeededResources = neededResources;
        Name = name;
        ItemDefinition = itemDefinition;
    }

    public bool CanCraft(Dictionary<ResourceType, Resource> availableResources)
    {
        foreach (var neededResource in NeededResources)
        {
            if (availableResources.ContainsKey(neededResource.Key.Type))
            {
                if (neededResource.Value > availableResources[neededResource.Key.Type].Amount)
                {
                    return false;
                }
            }
        }

        return true;
    }
}