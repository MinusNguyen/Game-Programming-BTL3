using System;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{

    [SerializeField] GameObject GameOverUI;
    [SerializeField] Settings SettingsUI;
    [SerializeField] TMP_Dropdown DifficultyDropdown;
    [SerializeField] TMP_Text ScoreText;
    [SerializeField] TMP_Text ScoreDisplay;

    public static UIManager Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HideAllUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayGameOver()
    {
        GameOverUI.SetActive(true);
        SettingsUI.gameObject.SetActive(false);

        string score = ScoreText.text;
        string highScore = PlayerPrefs.GetInt("HighScore", 0).ToString();
        ScoreDisplay.text = $"Score: {score}\nHigh Score: {highScore}";

        ScoreText.gameObject.SetActive(false);
    }

    public void DisplaySettings()
    {
        GameOverUI.SetActive(false);
        SettingsUI.gameObject.SetActive(true);
        ScoreText.gameObject.SetActive(false);
    }

    public void HideAllUI()
    {
        GameOverUI.SetActive(false);
        SettingsUI.gameObject.SetActive(false);
        ScoreText.gameObject.SetActive(true);
    }

    public void UpdateScore(int score)
    {
        ScoreText.text = score.ToString();
    }
}
