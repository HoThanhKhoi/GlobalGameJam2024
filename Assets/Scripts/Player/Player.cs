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
        stats = GetComponent<PlayerStats>();
    }


    private void Start()
    {
        currentHappiness = stats.maxHappiness.GetValue();
    }
    public void AddScore(int points)
    {
        score += points;
    }
}