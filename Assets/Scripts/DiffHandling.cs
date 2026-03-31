using UnityEngine;

public class DiffHandling : MonoBehaviour
{
    [SerializeField] Difficulty[] difficulties;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDifficultyChange(int difficulty)
    {
        if(difficulty >= 0 && difficulty< difficulties.Length)
        {
            difficulties[difficulty].DifficultySetup();
        }
    }
}
