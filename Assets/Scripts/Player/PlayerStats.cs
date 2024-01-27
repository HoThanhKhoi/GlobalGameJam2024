using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public PlayerStatSO playerStatSO;
    private float currentHappiness;
    private event Action onHappinessChanged;

    private void Start()
    {
        currentHappiness = playerStatSO.maxHappiness;
    }

    private void OnEnable()
    {
        onHappinessChanged += PlayerStats_onHappinessChanged;
    }

    private void OnDisable()
    {
        onHappinessChanged -= PlayerStats_onHappinessChanged;
    }

    private void PlayerStats_onHappinessChanged()
    {
        Debug.Log(currentHappiness);
    }

    private void Update()
    {
        Debug.Log(currentHappiness);
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
        onHappinessChanged?.Invoke();
        currentHappiness = currentHappiness + value * Time.deltaTime;
        currentHappiness = Mathf.Clamp(currentHappiness, 0, playerStatSO.maxHappiness);
    }

    public void DecreaseHappiness(float value)
    {
        onHappinessChanged?.Invoke(); //
        currentHappiness -= value;

        if (currentHappiness <= 0)
        {
            Time.timeScale = 0;
        }
    }
}
