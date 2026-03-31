using UnityEngine;

[CreateAssetMenu(fileName = "Difficulty", menuName = "Scriptable Objects/Difficulty")]
public class Difficulty : ScriptableObject
{
    [SerializeField] float interval;
    [SerializeField] float speedUpRate;

    public void DifficultySetup()
    {
        Spawner.instance.SetDiff(speedUpRate, interval);
        Debug.Log("Diffset:" +  interval.ToString() + speedUpRate.ToString());
    }
}
