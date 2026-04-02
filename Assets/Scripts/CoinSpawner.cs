using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private float spawnRate = 2f;
    [SerializeField] private float heightOffset = 2f;

    [SerializeField] float diffRate = 0.2f;
    [SerializeField] float diffInterval = 10f;

    private float timer = 0f;

    private void Start()
    {
        //SpawnCoin();
        StartCoroutine(DifficultyCoroutine(diffRate, diffInterval));
    }

    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            SpawnCoin();
            timer = 0;
        }
    }

    void SpawnCoin()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        Instantiate(coinPrefab, new Vector3(
            transform.position.x,
            Random.Range(lowestPoint, highestPoint),
            0),
            Quaternion.identity);
    }

    IEnumerator DifficultyCoroutine(float rate, float interval)
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);
        }
    }
}