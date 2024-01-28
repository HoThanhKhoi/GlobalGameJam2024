using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelWindow : MonoBehaviour
{ 
    private TextMeshProUGUI levelText;
    private Slider expBarSlider;
    public LevelSystem levelSystem { get; set; }

    private void Awake()
    {
        levelText = transform.Find("levelText").GetComponent<TextMeshProUGUI>();
        expBarSlider = GetComponent<Slider>();
    }


    private void SetExpBarSize(float expNormalized)
    {
        expBarSlider.value = expNormalized;
    }

    private void SetLevelNumber(int levelNumber)
    {
        levelText.text = "Level: " + (levelNumber + 1);
    }

    public void SetLevelSystem(LevelSystem levelSystem)
    {
        //Set the level system ibject
        this.levelSystem = levelSystem;

        //Update starting value
        SetLevelNumber(levelSystem.GetCurrentLevel());
        SetExpBarSize(levelSystem.GetExpNormalized());

        //Subscribe to events
        levelSystem.OnLevelChanged += LevelSystem_OnLevelChanged;
        levelSystem.OnExpChanged += LevelSystem_OnExpChanged;
    }

    private void LevelSystem_OnExpChanged(object sender, System.EventArgs e)
    {
        //Experience change, update bar size
        SetExpBarSize(levelSystem.GetExpNormalized());
    }

    private void LevelSystem_OnLevelChanged(object sender, System.EventArgs e)
    {
        //Level changed, update text
        SetLevelNumber(levelSystem.GetCurrentLevel());
        //levelSystem.UpdateMaxExp();
        UpgradeManager.Instance.SetActiveAllUpgradeButtons(true);
        Time.timeScale = 0;
    }
}
