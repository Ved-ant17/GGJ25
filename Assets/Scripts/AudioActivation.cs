using UnityEngine;

public class AudioActivation : MonoBehaviour
{
    [Header("Audio Settings")]
    public AudioClip audioClip; // The audio clip to play
    public AudioSource audioSource;

    [Header("Collision Settings")]
    public string submarineTag = "Submarine"; // Tag for the submarine object

    void Start()
    {
        // Initialize AudioSource and assign the clip
        //audioSource = gameObject.GetComponent<AudioSource>();
        /*audioSource.clip = audioClip;*/
        //audioSource.playOnAwake = false; // Prevent the audio from playing automatically
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the bubble collides with the submarine
        if (collision.gameObject.CompareTag(submarineTag))
        {
            Debug.Log("Bubble collided with submarine! Playing audio.");

            // Play the audio clip
            PlayAudio();

            // Optionally, destroy the bubble after playing the audio
            Destroy(gameObject, audioClip.length); // Delayed destroy to match the audio duration
        }
    }

    private void PlayAudio()
    {
        if ( audioSource != null)
        {
            // Play the full audio clip
            audioSource.clip = audioClip;
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("AudioClip or AudioSource is not set up correctly.");
        }
    }
}
