using System.Diagnostics;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [SerializeField] private AudioSource audioSource;
    public static AudioManager instance;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public void playPlayerSound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    public void playSound(AudioSource source, AudioClip clip)
    {
        source.PlayOneShot(clip);
    }
}
