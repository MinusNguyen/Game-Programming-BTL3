using UnityEngine;

public class SFXManager : MonoBehaviour
{
    [SerializeField] private AudioClip flapSound;
    [SerializeField] private AudioClip scoreSound;
    [SerializeField] private AudioClip gravityPipeSound;

    private AudioSource m_AudioSource;
    private AudioDistortionFilter m_DistortionFilter;
    private AudioLowPassFilter m_LowPassFilter;
    private AudioReverbFilter m_ReverbFilter;
    private bool m_IsPlaying = true;

    public static SFXManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
        m_DistortionFilter = GetComponent<AudioDistortionFilter>();
        m_LowPassFilter = GetComponent<AudioLowPassFilter>();
        m_ReverbFilter = GetComponent<AudioReverbFilter>();

        m_DistortionFilter.enabled = false;
        m_LowPassFilter.enabled = false;
        m_ReverbFilter.enabled = false;

        m_IsPlaying = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void InvertSFX()
    {
        m_DistortionFilter.enabled = !m_DistortionFilter.enabled;
        m_LowPassFilter.enabled = !m_LowPassFilter.enabled;
        m_ReverbFilter.enabled = !m_ReverbFilter.enabled;
    }

    public void PlayFlapSound()
    {
        if (m_IsPlaying) m_AudioSource.PlayOneShot(flapSound);
    }

    public void PlayScoreSound()
    {
        if (m_IsPlaying) m_AudioSource.PlayOneShot(scoreSound);
    }

    public void PlayGravityPipeSound()
    {
        if (m_IsPlaying) m_AudioSource.PlayOneShot(gravityPipeSound);
    }

    public void ToggleSFX()
    {
        m_IsPlaying = !m_IsPlaying;
        if (m_AudioSource == null)
        {
            m_AudioSource = GetComponent<AudioSource>();
        }
    }
}
