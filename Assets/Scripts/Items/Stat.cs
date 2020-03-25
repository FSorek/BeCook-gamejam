using System.Collections.Generic;
using UnityEngine;

public class Stat
{
    private bool _isDirty;
    private int _effectiveValue;
    private readonly List<StatModifier> _modifiers;
    public int BaseValue { get; }

    public int EffectiveValue
    {
        get
        {
            if (_isDirty)
            {
                _effectiveValue = CalculateEffectiveValue();
                _isDirty = false;
            }
            return _effectiveValue;
        }
    }

    public Stat(int baseValue)
    {
        BaseValue = baseValue;
        _effectiveValue = baseValue;
        _modifiers = new List<StatModifier>();
    }

    public void AddModifier(StatModifier modifier)
    {
        _isDirty = true;
        _modifiers.Add(modifier);
    }

    public void RemoveModifier(StatModifier modifier)
    {
        if (_modifiers.Contains(modifier))
        {
            _isDirty = true;
            _modifiers.Remove(modifier);
        }
    }

    private int CalculateEffectiveValue()
    {
        int finalValue = BaseValue;
        float percentageModification = 1f;

        for (int i = 0; i < _modifiers.Count; i++)
            percentageModification += _modifiers[i].Value;
        
        return Mathf.CeilToInt(finalValue * percentageModification);
    }
}