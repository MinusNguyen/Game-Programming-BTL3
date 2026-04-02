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
    [SerializeField] float minInterval = 0.8f;
    [SerializeField] float maxPipeSpeed = 15f;

    //nhi - add moving pipes
    [SerializeField] private GameObject Moving_pipe_prefab;
    [SerializeField, Range(0f, 1f)] private float movingPipeChance = 0.3f;
    //

    [SerializeField] float diffRate = 0.4f;
    [SerializeField] float diffInterval = 8f;

    private Coroutine difficultyCoroutine;

    private int pipesSpawned = 0;
    private bool spawnGravityPipe = false;
    private int gravityInvertThreshold;

    public static Spawner Instance;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }

        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        Spawn();
        // load persisted difficulty if available
        if (PlayerPrefs.HasKey("DifficultyRate") && PlayerPrefs.HasKey("DifficultyInterval"))
        {
            diffRate = PlayerPrefs.GetFloat("DifficultyRate");
            diffInterval = PlayerPrefs.GetFloat("DifficultyInterval");
        }
        difficultyCoroutine = StartCoroutine(DifficultyCoroutine(diffRate, diffInterval));
        gravityInvertThreshold = Random.Range(3, 11);
        Pipes.speed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        if (counter > intervals)
        {
            Spawn();
        }

        if (pipesSpawned >= gravityInvertThreshold)
        {
            spawnGravityPipe = true;
            gravityInvertThreshold = Random.Range(3, 11);
            pipesSpawned = 0;
        }
    }

    void Spawn()
    {
        if (spawnGravityPipe)
        {
            Instantiate(Gravity_pipe_prefab, new Vector3(transform.position.x, Random.Range(-border, border), 0), transform.rotation);
            spawnGravityPipe = false;
            SFXManager.Instance.PlayGravityPipeSound();
            Debug.Log("Spawned Gravity Pipe");
        }
        else
        { // nhi - thêm điều kiện để spawn moving pipe
            if (Random.value < movingPipeChance)
            {
                Instantiate(Moving_pipe_prefab, new Vector3(transform.position.x, Random.Range(-border, border), 0), transform.rotation);
                Debug.Log("Spawned Moving Pipe");
            }
            else
            {
                Instantiate(Pipe_prefab, new Vector3(transform.position.x, Random.Range(-border, border), 0), transform.rotation);
            }
        }
        pipesSpawned++;
        counter = 0;
    }

    IEnumerator DifficultyCoroutine(float rate, float interval)
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);
            Pipes.speed = (Pipes.speed >= maxPipeSpeed)? maxPipeSpeed : Pipes.speed + rate;
            intervals = (intervals <= minInterval)? minInterval : intervals - rate;
        }
    }

    public void SetDiff(float rate, float interval)
    {
        diffRate = rate;
        diffInterval = interval;
        // restart coroutine so the new rate/interval are used
        if (difficultyCoroutine != null)
        {
            StopCoroutine(difficultyCoroutine);
            difficultyCoroutine = null;
        }
        difficultyCoroutine = StartCoroutine(DifficultyCoroutine(diffRate, diffInterval));
    }
}
