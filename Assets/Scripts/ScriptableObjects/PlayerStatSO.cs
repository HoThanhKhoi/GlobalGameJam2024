using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStatSO", menuName = "ScriptableObjects/PlayerStatSO")]
public class PlayerStatSO : ScriptableObject
{
    [Header("Happiness")]
    public float maxHappiness;
    public float happinessDecreaseValue;
    public float happinessIncreaseValue;

    [Header("Attack")]
    public float attackSpeed;
    public int attackDamage;
    public float accuracy;

    [Header("Movement")]
    public float movementSpeed;
}
