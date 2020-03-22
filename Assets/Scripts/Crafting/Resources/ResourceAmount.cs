using System;
using UnityEngine;

[Serializable]
public struct ResourceAmount
{
    [SerializeField] private ResourceDefinition _resourceDefinition;
    [SerializeField] private int amount;
    
    public ResourceDefinition ResourceDefinition => _resourceDefinition;
    public int Amount => amount;
}