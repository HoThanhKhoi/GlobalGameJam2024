using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeButton : MonoBehaviour
{
    private Player player;
    private UpgradeManager upgradeManager;
    private void Start()
    {
        player = Player.Instance;
        upgradeManager = UpgradeManager.Instance;
    }
    public void UpgradeMoveSpeed()
    {
        player.stats.IncreaseStatPercent(player.stats.movementSpeed, upgradeManager.moveSpeedIncrementPercent);
    }

    public void UpgradeFireRate()
    {
        player.stats.DecreaseStatPercent(player.stats.fireRate, upgradeManager.fireRateDecrementPercent);
    }

    public void UpgradeAccuracy()
    {
        player.stats.DecreaseStatPercent(player.stats.inaccuracy, upgradeManager.accuracyDecrementPercent);
    }

    public void WhenUpgradeButtonClicked()
    {
        upgradeManager.SetActiveAllUpgradeButtons(false);
        Time.timeScale = 1;
    }
    
}
