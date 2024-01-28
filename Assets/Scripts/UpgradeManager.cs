using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager Instance { get; private set; }

    private LevelManager levelManager;

    public float moveSpeedIncrementPercent;
    public float fireRateDecrementPercent;
    public float accuracyDecrementPercent;

    public List<GameObject> upgradeButtonList;

    public event Action OnUpgradeButtonClicked;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance.gameObject);
        }
    }

    private void Start()
    {
        SetActiveAllUpgradeButtons(false);
    }

    public void SetActiveAllUpgradeButtons(bool active)
    {
        foreach (GameObject button in upgradeButtonList)
        {
            button.SetActive(active);
        }
    }


}
