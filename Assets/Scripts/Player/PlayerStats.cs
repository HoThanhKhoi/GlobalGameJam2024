using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private float currentHappiness;

    public event Action OnHappinessChanged;
    [SerializeField] private HappinessBar happinessBar;

    [Header("Happiness")]
    public Stat maxHappiness;
    public Stat happinessDecreaseValueWhenHit;
    public Stat happinessDecreaseValueWhenEscape;
    public Stat happinessIncreaseValueOverTime;

    [Header("Attack")]
    public Stat fireRate;
    public Stat inaccuracy;

    [Header("Movement")]
    public Stat movementSpeed;


    private void Start()
    {
        currentHappiness = maxHappiness.GetValue();
        happinessBar.UpdateBar(maxHappiness.GetValue(), currentHappiness);

        movementSpeed.OnValueChanged += MovementSpeed_OnValueChanged;
        fireRate.OnValueChanged += FireRate_OnValueChanged;
        inaccuracy.OnValueChanged += Inaccuracy_OnValueChanged;
    }

    private void Inaccuracy_OnValueChanged()
    {
        
    }

    private void FireRate_OnValueChanged()
    {
        
    }

    private void MovementSpeed_OnValueChanged()
    {
        Debug.Log(movementSpeed.GetValue());
    }

    private void OnEnable()
    {
        OnHappinessChanged += PlayerStats_onHappinessChanged;
    }

    private void OnDisable()
    {
        OnHappinessChanged -= PlayerStats_onHappinessChanged;
    }

    private void PlayerStats_onHappinessChanged()
    {
        happinessBar.UpdateBar(maxHappiness.GetValue(), currentHappiness);
    }

    private void Update()
    {
        if (!IsHappinessFull())
        {
            IncreaseHappiness(happinessIncreaseValueOverTime.GetValue());
        }
    }
    private bool IsHappinessFull()
    {
        return currentHappiness >= maxHappiness.GetValue();
    }
    public void IncreaseHappiness(float value)
    {
        OnHappinessChanged?.Invoke();
        currentHappiness = currentHappiness + value * Time.deltaTime;
        currentHappiness = Mathf.Clamp(currentHappiness, 0, maxHappiness.GetValue());
    }

    public void DecreaseHappiness(float value)
    {
        OnHappinessChanged?.Invoke(); //
        currentHappiness -= value;

        if (currentHappiness <= 0)
        {
            GameManager.Instance.EndGame();
        }
    }

    public void IncreaseStatValue(Stat stat, int value)
    {
        stat.Increase(value);
    }

    public void DecreaseStatValue(Stat stat, int value)
    {
        stat.Decrease(value);
    }

    public void IncreaseStatPercent(Stat stat, float percent)
    {
        stat.Increase((stat.GetValue() * percent/100));
    }

    public void DecreaseStatPercent(Stat stat, float percent)
    {
        stat.Decrease((stat.GetValue() * percent/100));
    }
}