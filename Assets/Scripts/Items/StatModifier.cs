using System;
using UnityEngine;

[Serializable]
public class StatModifier
{
    [SerializeField] private StatType _statToModify;
    [SerializeField][Range(0,1)] private float _value;
    public StatType StatToModify => _statToModify;
    public float Value => _value;

    public StatModifier(int value, StatType statToModify)
    {
        _statToModify = statToModify;
        _value = value;
    }

    public StatModifier()
    {
    }
}