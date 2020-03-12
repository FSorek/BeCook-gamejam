using UnityEngine;

[CreateAssetMenu(fileName = "Resource Definition")]
public class ResourceDefinition : ScriptableObject
{
    [SerializeField] private string _displayName;
    [SerializeField] private Sprite _icon;
    [SerializeField] private ResourceType _type;
    [SerializeField] private int _startingAmount;

    public string DisplayName => _displayName;
    public Sprite Icon => _icon;
    public ResourceType Type => _type;
    public int StartingAmount => _startingAmount;
}