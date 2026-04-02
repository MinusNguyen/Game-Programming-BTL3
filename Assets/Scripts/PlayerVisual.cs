using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    [SerializeField] ParticleSystem flapVFX;
    
    private Animator animator;
    private const string FLAP_TRIGGER = "Flap";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Flap()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
        animator.SetTrigger(FLAP_TRIGGER);

        flapVFX.Play();
    }
}
