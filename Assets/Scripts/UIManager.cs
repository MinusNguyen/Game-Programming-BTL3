using UnityEngine;

public class UIManager : MonoBehaviour
{

    [SerializeField] GameObject GameOverUI;
    [SerializeField] GameObject SettingsUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayGameOver()
    {
        GameOverUI.SetActive(true);
        SettingsUI.SetActive(false);
    }

    public void DisplaySettings()
    {
        GameOverUI.SetActive(false);
        SettingsUI.SetActive(true);
    }
}
