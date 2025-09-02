using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    AudioSource audioSource;
    [SerializeField] AudioClip[] BGMs;
    [SerializeField] AudioClip[] SEs;

    public enum BGM
    {
        main, clear1, clear2
    }

    public enum SE
    {
        coin1, coin2
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayBGM(int BGMindex)
    {
        audioSource.clip = BGMs[BGMindex];
        audioSource.Play();
    }

    public void PlaySE(int SEindex)
    {
        audioSource.PlayOneShot(SEs[SEindex]);
    }
}
