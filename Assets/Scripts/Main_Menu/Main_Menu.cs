using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Main_Menu : MonoBehaviour
{
    public GameObject settingsMenu;
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Settings()
    {
        if (settingsMenu != null)
        {
            settingsMenu.SetActive(true);
        }
    }

    public void TurnOffSettings()
    {
        settingsMenu?.SetActive(false);
    }
}
