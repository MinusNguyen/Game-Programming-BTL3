using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioClip musicClip;
    [SerializeField] private AudioClip gameOverClip;
    
    private AudioSource m_AudioSource;
    private AudioDistortionFilter m_DistortionFilter;
    private AudioHighPassFilter m_HighPassFilter;
    private AudioReverbFilter m_ReverbFilter;

    public static MusicManager Instance { get; private set; }

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
        m_HighPassFilter = GetComponent<AudioHighPassFilter>();
        m_ReverbFilter = GetComponent<AudioReverbFilter>();
        
        m_DistortionFilter.enabled = false;
        m_HighPassFilter.enabled = false;
        m_ReverbFilter.enabled = false;

        m_AudioSource.clip = musicClip;
        m_AudioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InvertMusic()
    {
        m_DistortionFilter.enabled = !m_DistortionFilter.enabled;
        m_HighPassFilter.enabled = !m_HighPassFilter.enabled;
        m_ReverbFilter.enabled = !m_ReverbFilter.enabled;
    }

    public void PlayGameOverMusic()
    {
        m_AudioSource.Stop();
        m_AudioSource.clip = gameOverClip;
        m_AudioSource.Play();
    }
}
