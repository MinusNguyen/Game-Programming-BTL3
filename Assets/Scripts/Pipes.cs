using System.Collections;
using UnityEngine;

public class Pipes : MonoBehaviour
{
    public static float speed = 5f;
    [SerializeField] float leftBorder = -24f;

    [SerializeField] GameObject lowerPipe;
    [SerializeField] float gapVariation = 3f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lowerPipe.transform.localPosition = new Vector3(
            lowerPipe.transform.localPosition.x,
            lowerPipe.transform.localPosition.y + Random.Range(0, gapVariation),
            lowerPipe.transform.localPosition.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        if(transform.position.x < leftBorder)
        {
            Destroy(gameObject);
        }

        Debug.Log($"Pipe speed: {speed}");
    }
}
