using UnityEngine;

[CreateAssetMenu(fileName = "Difficulty", menuName = "Scriptable Objects/Difficulty")]
public class Difficulty : ScriptableObject
{
    [SerializeField] float interval;
    [SerializeField] float speedUpRate;

    public void DifficultySetup()
    {
        // persist difficulty values so Spawner can apply them on Start
        PlayerPrefs.SetFloat("DifficultyRate", speedUpRate);
        PlayerPrefs.SetFloat("DifficultyInterval", interval);
        PlayerPrefs.Save();

        if (Spawner.Instance != null)
        {
            Spawner.Instance.SetDiff(speedUpRate, interval);
        }
        Debug.Log("Diffset: interval=" + interval.ToString() + " rate=" + speedUpRate.ToString());
    }

    public float GetInterval() => interval;
    public float GetSpeedUpRate() => speedUpRate;
}
