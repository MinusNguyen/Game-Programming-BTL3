using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] GameObject Pipe_prefab;
    [SerializeField] private GameObject Gravity_pipe_prefab;
    [SerializeField] float intervals = 3f;
    [SerializeField] float counter = 0;
    [SerializeField] float border = 4f;


    [SerializeField] float diffRate = 0.2f;
    [SerializeField] float diffInterval = 10f;

    private int pipesSpawned = 0;
    private bool gravityInverted = false;
    private int gravityInvertThreshold;

    void Start()
    {
        Spawn();
        StartCoroutine(DifficultyCoroutine(diffRate, diffInterval));
        gravityInvertThreshold = Random.Range(3, 11);
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        if (counter > intervals)
        {
            Spawn();
            counter = 0;
        }

        if (pipesSpawned >= gravityInvertThreshold)
        {
            gravityInverted = !gravityInverted; // Toggle gravity state
            gravityInvertThreshold = Random.Range(3, 11);
            pipesSpawned = 0;
        }
    }

    void Spawn()
    {
        if (gravityInverted)
        {
            Instantiate(Gravity_pipe_prefab, new Vector3(transform.position.x, Random.Range(-border, border), 0), transform.rotation);
            gravityInverted = false;
            Debug.Log("Spawned Gravity Pipe");
        }
        else
        {
            Instantiate(Pipe_prefab, new Vector3(transform.position.x, Random.Range(-border, border), 0), transform.rotation);
        }
        pipesSpawned++;
    }

    IEnumerator DifficultyCoroutine(float rate, float interval)
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);
            Pipes.speed += rate;
        }
    }
}
