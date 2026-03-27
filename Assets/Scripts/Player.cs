using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public float strength = 7f;
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
            rigidbody.linearVelocity = Vector2.up * strength;
        }
    }
}
