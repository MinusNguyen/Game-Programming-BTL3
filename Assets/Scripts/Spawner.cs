using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject Pipe_prefab;
    [SerializeField] float intervals = 3f;
    [SerializeField] float counter = 0;
    [SerializeField] float border = 4f;

    void Start()
    {
        Spawn();
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
    }

    void Spawn()
    {
        Instantiate(Pipe_prefab, new Vector3(transform.position.x, Random.Range(-border, border), 0), transform.rotation);
    }
}
