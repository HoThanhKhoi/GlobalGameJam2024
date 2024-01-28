using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeButton : MonoBehaviour
{
    private UpgradeManager upgradeManager;
    private void Start()
    {
        upgradeManager = UpgradeManager.Instance;
    }
    public void UpgradeMoveSpeed()
    {
        upgradeManager.playerStatSO.movementSpeed += upgradeManager.moveSpeedIncrement * upgradeManager.playerStatSO.movementSpeed;
        WhenUpgradeButtonClicked();
    }

    public void UpgradeFireRate()
    {
        upgradeManager.playerStatSO.fireRate += upgradeManager.fireRateIncrement * upgradeManager.playerStatSO.fireRate;
        WhenUpgradeButtonClicked();
    }

    public void UpgradeAccuracy()
    {
        upgradeManager.playerStatSO.inaccuracy -= upgradeManager.accuracyIncrement * upgradeManager.playerStatSO.inaccuracy;
        WhenUpgradeButtonClicked();
    }

    public void WhenUpgradeButtonClicked()
    {
        upgradeManager.SetActiveAllUpgradeButtons(false);
        Time.timeScale = 1;
    }
    
}
