using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelBar : MonoBehaviour
{
    [SerializeField] private Image barImage;
    public event Action OnExpChanged;

    private void Start()
    {
        OnExpChanged += LevelBar_OnExpChanged;
    }

    private void LevelBar_OnExpChanged()
    {
        
    }

    private void UpdateBar()
    {
        
    }
}