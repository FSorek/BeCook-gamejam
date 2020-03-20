using System;
using UnityEngine;

[Serializable]
public class StatModifier
{
    [SerializeField] private StatType _statType;
    [SerializeField] private float _value;
    public StatType StatType => _statType;
    public float Value => _value;

    public StatModifier(int value, StatType statType)
    {
        _statType = statType;
        _value = value;
    }

    public StatModifier()
    {
    }
}