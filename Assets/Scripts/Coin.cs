using UnityEngine;

public class Coin : MonoBehaviour
{
    public static float speed = 5f;
    [SerializeField] float leftBorder = -24f;
    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        if (transform.position.x < leftBorder)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.instance.AddScore();
            Destroy(gameObject);
        }
    }
}