using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private int menuSceneIndex = 0;
    [SerializeField] private int gameSceneIndex = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene(menuSceneIndex);
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene(gameSceneIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
