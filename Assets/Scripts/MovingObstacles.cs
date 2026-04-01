using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    [SerializeField] private float amplitude = 1.2f;   // Độ cao dao động
    [SerializeField] private float frequency = 2f;     // Tốc độ dao động
    [SerializeField] private bool randomPhase = true;  // Mỗi pipe dao động lệch nhau

    private float startY;
    private float phaseOffset;

    void Start()
    {
        startY = transform.position.y;
        phaseOffset = randomPhase ? Random.Range(0f, Mathf.PI * 2f) : 0f;
    }

    void Update()
    {
        float newY = startY + Mathf.Sin(Time.time * frequency + phaseOffset) * amplitude;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}