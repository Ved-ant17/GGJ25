using UnityEngine;

public class BubblePop : MonoBehaviour
{
    public GameObject popEffect; // Particle effect or animation for the pop
    public AudioClip popSound;  // Sound effect for the pop
    private AudioSource audioSource;

    void Start()
    {
        // Optional: Initialize audio source
        if (popSound != null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = popSound;
        }
    }

    // Trigger collision detection
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the bubble collides with the submarine
        if (collision.gameObject.CompareTag("Submarine"))
        {
            Debug.Log("game over TODO");
            // Play pop effect
            if (popEffect != null)
            {
                Instantiate(popEffect, transform.position, Quaternion.identity);
            }

            // Play sound effect
            if (popSound != null && audioSource != null)
            {
                audioSource.Play();
            }

            // Destroy the bubble
            Destroy(gameObject);
        }
    }
}
