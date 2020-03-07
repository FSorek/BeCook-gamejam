using System;
using UnityEngine;

[Serializable]
public struct ResourceAmount
{
    [SerializeField] private Resources resource;
    [SerializeField] private int amount;
    
    public Resources Resource => resource;
    public int Amount => amount;
}