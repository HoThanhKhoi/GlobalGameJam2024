using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public PlayerStatSO playerStatSO;
    private float currentHappiness;

    public event Action OnHappinessChanged;
    [SerializeField] private HappinessBar happinessBar;

    private void Start()
    {
        currentHappiness = playerStatSO.maxHappiness;
        happinessBar.UpdateBar(playerStatSO.maxHappiness, currentHappiness);
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
        happinessBar.UpdateBar(playerStatSO.maxHappiness, currentHappiness);
    }

    private void Update()
    {
        if (!IsHappinessFull())
        {
            IncreaseHappiness(playerStatSO.happinessIncreaseValue);
        }
    }
    private bool IsHappinessFull()
    {
        return currentHappiness >= playerStatSO.maxHappiness;
    }
    public void IncreaseHappiness(float value)
    {
        OnHappinessChanged?.Invoke();
        currentHappiness = currentHappiness + value * Time.deltaTime;
        currentHappiness = Mathf.Clamp(currentHappiness, 0, playerStatSO.maxHappiness);
    }

    public void DecreaseHappiness(float value)
    {
        OnHappinessChanged?.Invoke(); //
        currentHappiness -= value;

        if (currentHappiness <= 0)
        {
            Time.timeScale = 0;
        }
    }
}