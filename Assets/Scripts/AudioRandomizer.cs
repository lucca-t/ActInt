using UnityEngine;

public class AudioRandomizer : MonoBehaviour
{
    private AudioSource audioSource;

    [SerializeField]
    private float minPitch = 0.85f;
    [SerializeField]
    private float maxPitch = 1.15f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioSource != null)
        {
            audioSource.pitch = Random.Range(minPitch, maxPitch);
            
            audioSource.Play();
        }
    }
}