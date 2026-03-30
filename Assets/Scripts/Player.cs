using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public float strength = 7f;

    private const string SCORE_TAG = "Score";
    private const string INVERT_GRAVITY_TAG = "Invert Gravity";

    public static Player instance { private set; get; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            rigidBody.linearVelocity = Vector2.up * strength;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(SCORE_TAG))
        {
            Debug.Log("Score!");
        }
        else if (collision.gameObject.CompareTag(INVERT_GRAVITY_TAG))
        {
            Debug.Log("Gravity Inverted!");
            GameManager.instance.InvertGravity();
            strength = -strength; // Invert the jump strength to match the new gravity direction
        }
        else
        {
            GameManager.instance.GameOver();
        }
    }
}
