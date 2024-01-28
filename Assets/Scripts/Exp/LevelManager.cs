using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }
    [SerializeField] private LevelWindow levelWindow;
    public LevelSystem levelSystem { get; set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        levelSystem = new LevelSystem();
        
    }

    private void Start()
    {
        levelWindow.SetLevelSystem(levelSystem);
    }

    public void AddExp(int amount)
    {
        levelSystem.AddExp(amount);
    }
}
