using UnityEngine;
using UnityEngine.SceneManagement; // For restarting the game or switching scenes

public class GameOverTrigger : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the object that collided has the tag "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Game Over! Bubble hit the log." + collision.gameObject.name);

            // Call the GameOver logic
            GameOver();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Alternative trigger check (if using triggers instead of collisions)
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Game Over! Bubble hit the log."+ collision.gameObject.name);
            GameOver();
        }
    }

    private void GameOver()
    {
        // Game over logic here (e.g., reload the scene, show UI, etc.)
        // For example, restart the scene:
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        // Or display a Game Over UI (replace with your own implementation)
        // Debug.Log("Game Over UI would be displayed here.");
    }
}
