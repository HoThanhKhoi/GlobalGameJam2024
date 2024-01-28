using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    private event Action OnScoreChanged;
    [SerializeField] private bool isGameOver;
    [SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private Image gameOverImage;
    [SerializeField] private Button replayButton;
    [SerializeField] private Button mainMenuButton;
    public static GameManager Instance { get; private set; }

    public int highScore = 0;
    public int bestScore;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        OnScoreChanged += GameManager_OnScoreChanged;
        UpdateScoreUI();
        bestScore = PlayerPrefs.GetInt("HighScore", 0);
        scoreText.text = "Score: " + highScore;

        gameOverText.gameObject.SetActive(false);
        titleText.gameObject.SetActive(false);
        gameOverImage.gameObject.SetActive(false);
        mainMenuButton.gameObject.SetActive(false);
        replayButton.gameObject.SetActive(false);

        //gameOverText.enabled = false;
        //titleText.enabled = false;
        //gameOverImage.enabled = false;
        //mainMenuButton.enabled = false;
        //replayButton.enabled = false;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && isGameOver == true)
        {
            SceneManager.LoadScene(1);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

    public void Replay()
    {
        if(isGameOver == true)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(1);
        }
    }

    public void MainMenu()
    {
        if (isGameOver == true)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
        }
    }

    public void GameOver()
    {
        isGameOver = true;
    }
    private void GameManager_OnScoreChanged()
    {
        UpdateScoreUI();
    }

    public void AddScore(int amount)
    {
        highScore += amount;
        OnScoreChanged?.Invoke();
    }

    public int getCurrentScore()
    {
        return highScore;
    }

    private void UpdateScoreUI()
    {
        scoreText.text = "Score: " + getCurrentScore().ToString();

        CheckForBestScore();
    }

    public void CheckForBestScore()
    {
        if (highScore > bestScore)
        {
            bestScore = highScore;
            PlayerPrefs.SetInt("HighScore", bestScore);
            PlayerPrefs.Save();
        }
    }

    public void EndGame()
    {
        gameOverText.gameObject.SetActive(true);
        gameOverText.text = "You have killed " + getCurrentScore().ToString() + " cat(s), congrats?...";

        titleText.gameObject.SetActive(true);
        gameOverImage.gameObject.SetActive(true);
        mainMenuButton.gameObject.SetActive(true);
        replayButton.gameObject.SetActive(true);
        Time.timeScale = 0;
        GameOver();
    }
}