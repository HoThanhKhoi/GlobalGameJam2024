using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStatSO", menuName = "ScriptableObjects/PlayerStatSO")]
public class PlayerStatSO : ScriptableObject
{
    [Header("Happiness")]
    public float maxHappiness;
    public float happinessDecreaseValueWhenHit;
    public float happinessDecreaseValueWhenEscape;
    public float happinessDecreaseValueWhenCrashHitler;
    public float happinessIncreaseValue;

    [Header("Attack")]
    public float fireRate;
    public int attackDamage;
    public float accuracy;

    [Header("Movement")]
    public float movementSpeed;

    [Header("Exp")]
    public int expGainPerKill;
}