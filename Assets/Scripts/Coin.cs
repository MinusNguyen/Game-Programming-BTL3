using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] float leftBorder = -24f;

    // Update is called once per frame
    void Update()
    {
        float speed = Pipes.speed;
        transform.position += Vector3.left * speed * Time.deltaTime;
        if (transform.position.x < leftBorder)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}