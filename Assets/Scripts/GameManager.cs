using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private GameObject globalVolume;
    [SerializeField] private GameObject backgrounds;

    const string HIGH_SCORE_KEY = "HighScore";
    [SerializeField] int score;
    [SerializeField] int highScore;

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
        Time.timeScale = 1f;
        Physics2D.gravity = new Vector2(0, -9.81f);
        score = 0;
        UIManager.Instance.UpdateScore(score);
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
        MusicManager.Instance.InvertMusic();
        // apply SFX filters when gravity inverts
        if (SFXManager.Instance != null)
        {
            SFXManager.Instance.InvertSFX();
        }
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt(HIGH_SCORE_KEY, highScore);
        }
        UIManager.Instance.DisplayGameOver();
        MusicManager.Instance.PlayGameOverMusic();
        SFXManager.Instance.ToggleSFX();
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        UIManager.Instance.HideAllUI();
        score = 0;
    }

    public void AddScore()
    {
        score++;
        UIManager.Instance.UpdateScore(score);
        SFXManager.Instance.PlayScoreSound();
    }
}
