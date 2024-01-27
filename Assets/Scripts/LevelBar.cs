using System;
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
