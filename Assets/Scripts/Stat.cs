using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat
{
    [SerializeField] private float baseValue;

    public event Action OnValueChanged;

    public float GetValue()
    {
        float finalValue = baseValue;

        return finalValue;
    }

    public void SetDefaultValue(float value)
    {
        baseValue = value;
    }

    public void Increase(float modifier)
    {
        baseValue += modifier;
        OnValueChanged?.Invoke();
    }

    public void Decrease(float modifier)
    {
        baseValue -= modifier;
        if(baseValue <= 0)
        {
            baseValue = 0;
        }
        OnValueChanged?.Invoke();
    }
}
