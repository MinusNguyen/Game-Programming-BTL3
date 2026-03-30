using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] GameObject GameOverScreen;
    [SerializeField] private GameObject globalVolume;
    [SerializeField] private GameObject backgrounds;

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
        GameOverScreen.SetActive(true);
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        GameOverScreen.SetActive(false);
    }
}
