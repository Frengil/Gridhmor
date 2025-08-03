using UnityEngine;

public class Footsteps : MonoBehaviour
{

    [SerializeField] private AudioClip[] footStepFX;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float playRate;
    private float lastPlayTime;


    void Update()
    {
        if (rb.linearVelocity.magnitude > 0 && Time.time - lastPlayTime > playRate)
        {
            Play();
        }
    }

    void Play()
    {
        lastPlayTime = Time.time;
        AudioClip clipToPlay = footStepFX[Random.Range(0, footStepFX.Length)];
        audioSource.PlayOneShot(clipToPlay);
    }


}
