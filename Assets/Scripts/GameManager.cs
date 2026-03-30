using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] GameObject GameOverScreen;
    public int playerScore;
    public int highScore;
    public Text scoreText;
    public Text highscoreText;
    public TMP_Text finalScore;
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
        scoreText.text = "Score: " + playerScore.ToString();
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highscoreText.text = "High Score: " + highScore.ToString();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    [ContextMenu("Increase score")]
    public void AddScore()
    {
        playerScore += 1;
        scoreText.text = "Score: " + playerScore.ToString();
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        GameOverScreen.SetActive(true);
        if (playerScore > highScore)
        {
            highScore = playerScore;
            PlayerPrefs.SetInt("HighScore", highScore);
            highscoreText.text = "High Score: " + highScore.ToString();
        }
        finalScore.text = "Your score: " + playerScore.ToString() + "\nHigh Score: " + highScore.ToString();
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        GameOverScreen.SetActive(false);
    }
}
