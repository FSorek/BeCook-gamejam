using System;
using UnityEngine;

[Serializable]
public struct ResourceAmount
{
    [SerializeField] private ResourceType _resourceType;
    [SerializeField] private int amount;
    
    public ResourceType ResourceType => _resourceType;
    public int Amount => amount;
}