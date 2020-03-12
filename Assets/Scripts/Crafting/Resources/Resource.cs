using UnityEngine;

public class Resource
{
    public int Amount { get; set; }
    public string DisplayName{ get;}
    public Sprite Icon  { get; }
    public ResourceType Type { get; }
    
    public Resource(ResourceDefinition resourceDefinition)
    {
        DisplayName = resourceDefinition.DisplayName;
        Icon = resourceDefinition.Icon;
        Type = resourceDefinition.Type;
    }
}