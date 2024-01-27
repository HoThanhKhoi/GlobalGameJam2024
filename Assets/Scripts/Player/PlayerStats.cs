using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private PlayerStatSO playerStatSO;
    private float currentHappiness;

    private event Action onHappinessChanged;

    private void OnEnable()
    {
        Cat.OnHappinessChanged += Cat_OnHappinessChanged;
        onHappinessChanged += PlayerStats_onHappinessChanged;
    }

    private void PlayerStats_onHappinessChanged()
    {
        Debug.Log(currentHappiness);
    }

    private void OnDisable()
    {
        Cat.OnHappinessChanged -= Cat_OnHappinessChanged;
        onHappinessChanged -= PlayerStats_onHappinessChanged;

    }

    private void Cat_OnHappinessChanged()
    {
        DecreaseHappiness();
    }

    private void Start()
    {
        currentHappiness = playerStatSO.maxHappiness;
    }

    private void Update()
    {
        if (!IsHappinessFull())
        {
            AddHappiness(playerStatSO.happinessIncreaseValue);
        }
    }
    private bool IsHappinessFull() => currentHappiness >= playerStatSO.maxHappiness; //m
    public void AddHappiness(float value)
    {
        onHappinessChanged?.Invoke();
        currentHappiness = currentHappiness + value * Time.deltaTime;
        currentHappiness = Mathf.Clamp(currentHappiness, 0, playerStatSO.maxHappiness);
    }

    public void DecreaseHappiness()
    {
        onHappinessChanged?.Invoke(); //
        currentHappiness -= playerStatSO.happinessDecreaseValue;
        Debug.Log(currentHappiness);

        if (currentHappiness <= 0)
        {
            Time.timeScale = 0;
        }
    }
}
