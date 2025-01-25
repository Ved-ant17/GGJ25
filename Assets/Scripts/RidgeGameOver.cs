using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; // Import SceneManager for scene transitions

public class RidgeGameOver : MonoBehaviour
{
    public string bubbleTag = "Player0"; // Tag for the bubble GameObject
    public string mainMenuSceneName = "MainMenu"; // Name of your main menu scene
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


        // Load the Main Menu scene after a short delay
       
            StartCoroutine(LoadMainMenu());
        // Optionally stop the game
    }


    public IEnumerator LoadMainMenu()
    {
        //Time.timeScale = 0; // Pause the game
        yield return new WaitForSeconds(0f);
        Debug.Log("LoadMainMenu");
        // Resume the game time scale
        Time.timeScale = 1;

        // Load the Main Menu scene
        SceneManager.LoadScene("FrontScreen");
    }
}
