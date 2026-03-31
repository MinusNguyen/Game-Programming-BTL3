using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] GameObject GameOverScreen;
    [SerializeField] private GameObject globalVolume;
    [SerializeField] private GameObject backgrounds;

    const string HIGH_SCORE_KEY = "HighScore";
    [SerializeField] int score;
    [SerializeField] int highScore;
    [SerializeField] TMP_Text ScoreDisplay;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }

        else
        {
            instance = this;
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Physics2D.gravity = new Vector2(0, -9.81f);
        highScore = PlayerPrefs.GetInt(HIGH_SCORE_KEY, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InvertGravity()
    {
        Physics2D.gravity = new Vector2(0, -Physics2D.gravity.y);
        globalVolume.GetComponent<Volume>().weight = (globalVolume.GetComponent<Volume>().weight == 0) ? 1 : 0; ;
        backgrounds.transform.localScale = new Vector3(1, -backgrounds.transform.localScale.y, 1);
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt(HIGH_SCORE_KEY, highScore);
        }
        ScoreDisplay.text = $"Score: {score}\nHigh score: {highScore}";
        GameOverScreen.SetActive(true);
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        GameOverScreen.SetActive(false);
        score = 0;
    }

    public void AddScore()
    {
        score++;
    }
}
