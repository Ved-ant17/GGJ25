using UnityEngine;

public class ObjectController : MonoBehaviour
{
    // Movement speed
    public float speed = 5f;

    // Configurable keys for movement
    public KeyCode moveUp = KeyCode.W;       // Move up
    public KeyCode moveDown = KeyCode.S;     // Move down
    public KeyCode moveLeft = KeyCode.A;     // Move left
    public KeyCode moveRight = KeyCode.D;    // Move right

    void Update()
    {
        // Initialize movement variables
        float horizontal = 0f;
        float vertical = 0f;
        float depth = 0f;

        // Handle movement based on configurable keys
        if (Input.GetKey(moveUp)) vertical = 1f;        // Move along Y-axis
        if (Input.GetKey(moveDown)) vertical = -1f;     // Move along Y-axis
        if (Input.GetKey(moveLeft)) horizontal = -1f;   // Move along X-axis
        if (Input.GetKey(moveRight)) horizontal = 1f;   // Move along X-axis

        // Calculate movement vector
        Vector3 movement = new Vector3(horizontal, vertical, depth) * speed * Time.deltaTime;

        // Apply movement
        transform.Translate(movement, Space.World);
    }
}
