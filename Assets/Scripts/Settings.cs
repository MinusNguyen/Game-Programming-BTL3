using TMPro;
using UnityEngine;

public class Settings : MonoBehaviour
{
    [SerializeField] TMP_Dropdown DifficultyDropdown;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float diffRate = PlayerPrefs.GetFloat("DifficultyRate");
        float diffInterval = PlayerPrefs.GetFloat("DifficultyInterval");
        if (diffRate == 0.5f && diffInterval == 8f)
        {
            DifficultyDropdown.value = 0; // Easy
        }
        else if (diffRate == 0.8f && diffInterval == 6f)
        {
            DifficultyDropdown.value = 1; // Medium
        }
        else if (diffRate == 1f && diffInterval == 4f)
        {
            DifficultyDropdown.value = 2; // Hard
        }
        else
        {
            DifficultyDropdown.value = 0; // Fallback to Default
        }
    }
}
