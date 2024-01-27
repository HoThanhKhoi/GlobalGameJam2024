using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HappinessBar : MonoBehaviour
{
    private Slider slider;
    private float maxHappiness;
    private float currentHappiness;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    public void UpdateBar(float _maxValue, float _currentValue)
    {
        slider.maxValue = _maxValue;
        slider.value = _currentValue;
    }
}
