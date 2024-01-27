using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStatSO", menuName = "ScriptableObjects/PlayerStatSO")]
public class PlayerStatSO : ScriptableObject
{
    [Header("Happiness")]
    public int maxHappiness;
    public int happinessDecreaseValue;

    [Header("Attack")]
    public float attackSpeed;
    public int attackDamage;
    public float accuracy;

    [Header("Movement")]
    public float movementSpeed;
}
