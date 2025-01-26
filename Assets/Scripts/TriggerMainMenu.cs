using UnityEngine;

public class TriggerMainMenu : MonoBehaviour
{
    [Header("References")]
    public Canvas mainMenuCanvas; // Reference to the main menu canvas

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the colliding object is the bubble
        if (collision.gameObject.CompareTag("Bubble")) // Ensure the bubble has the "Bubble" tag
        {
            // Activate the main menu
            if (mainMenuCanvas != null)
            {
                mainMenuCanvas.gameObject.SetActive(true);
            }

            // Optional: Disable the bubble or stop its movement
            collision.gameObject.SetActive(false);

            Debug.Log("Bubble touched the ridge! Main menu activated.");
        }
    }
}
