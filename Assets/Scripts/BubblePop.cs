using UnityEngine;
using UnityEngine.SceneManagement; // For Game Over scene reload or logic

public class BubblePop : MonoBehaviour
{
    [Header("Pop Effect Settings")]
    public GameObject popEffect; // Particle effect or animation for the pop
    public AudioClip popSound;  // Sound effect for the pop

    [Header("Game Over Settings")]
    public string submarineTag = "Submarine"; // Tag for the submarine object

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
        // If bubble collides with the submarine
        if (collision.gameObject.CompareTag(submarineTag))
        {
            Debug.Log("Bubble popped!");

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
            GameOver();
        }
    }

    private void GameOver()
    {
        // Game over logic here (e.g., reload the scene, show UI, etc.)
        Debug.Log("Game Over Triggered!");

        // Example: Restart the scene
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("Assets/Scenes/GameOver.unity");

        // Alternatively, you can pause the game and display a UI
        // Time.timeScale = 0f;
        // DisplayGameOverUI();
    }
}