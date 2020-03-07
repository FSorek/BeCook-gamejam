using System.Collections.Generic;

public class Recipe
{
    public Dictionary<Resources, int> ResourcesNeeded { get; }
    public string Name { get; }
    
    public Recipe(Dictionary<Resources, int> resourcesNeeded,string name)
    {
        ResourcesNeeded = resourcesNeeded;
        Name = name;
    }
}