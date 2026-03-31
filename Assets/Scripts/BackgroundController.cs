using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    [SerializeField] private float parallaxEffect = 0.5f;

    private float length;
    private float startPos;

    void Start()
    {
        // Get the width of the background sprite
        length = GetComponent<SpriteRenderer>().bounds.size.x;

        // Save the exact starting X position
        startPos = transform.position.x;
    }

    void Update()
    {
        // Calculate how much to move this frame
        float moveAmount = Pipes.speed * parallaxEffect * Time.deltaTime;

        // Move the background to the left
        transform.position += new Vector3(-moveAmount, 0, 0);

        // Check if it has moved past its own length
        if (transform.position.x <= startPos - length)
        {
            transform.position = new Vector3(transform.position.x + length, transform.position.y, transform.position.z);
        }
    }
}