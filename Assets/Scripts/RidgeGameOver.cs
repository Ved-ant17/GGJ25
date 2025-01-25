using UnityEngine;

public class RidgeGameOver : MonoBehaviour
{
    public string bubbleTag = "Player"; // Tag for the bubble GameObject
    public GameObject gameOverUI;      // Reference to the Game Over UI

    private void Start()
    {
        // Ensure the Game Over UI is hidden at the start
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the colliding object has the bubble tag
        if (other.CompareTag(bubbleTag))
        {
            // Trigger Game Over
            GameOver();
        }
    }

    private void GameOver()
    {
        Debug.Log("Game Over! The bubble touched the rig.");
        
        // Show the Game Over UI if it's assigned
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true);
        }

        // Optionally stop the game or reset the scene
        Time.timeScale = 0; // Pause the game
        // You can reload the scene if needed:
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
