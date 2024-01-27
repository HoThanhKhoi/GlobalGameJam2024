using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    private float score;

    public PlayerStats stats { get; private set; }
    private float currentHappiness;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance.gameObject);
        }
        else
        {
            Instance = this;
        }
    }


    private void Start()
    {
        stats = GetComponent<PlayerStats>();

        currentHappiness = stats.playerStatSO.maxHappiness;
    }
    public void AddScore(int points)
    {
        score += points;
    }
}
