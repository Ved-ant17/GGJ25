using UnityEngine;

public class ObjectBinder : MonoBehaviour
{
    public float speed = 5f;  // Movement speed

    // Configurable keys for movement
    public KeyCode moveUp = KeyCode.W;
    public KeyCode moveDown = KeyCode.S;
    public KeyCode moveLeft = KeyCode.A;
    public KeyCode moveRight = KeyCode.D;

    // Define the screen boundaries (in world space)
    public float minX = -5f;  // Minimum X boundary
    public float maxX = 5f;   // Maximum X boundary
    public float minY = -5f;  // Minimum Y boundary
    public float maxY = 5f;   // Maximum Y boundary

    void Update()
    {
        // Initialize movement variables
        float horizontal = 0f;
        float vertical = 0f;

        // Handle movement based on configurable keys
        if (Input.GetKey(moveUp)) vertical = 1f;  // Move up
        if (Input.GetKey(moveDown)) vertical = -1f;  // Move down
        if (Input.GetKey(moveLeft)) horizontal = -1f;  // Move left
        if (Input.GetKey(moveRight)) horizontal = 1f;  // Move right

        // Calculate movement vector
        Vector3 movement = new Vector3(horizontal, vertical, 0f) * speed * Time.deltaTime;

        // Apply movement
        transform.Translate(movement, Space.World);

        // Clamp the position within the defined boundaries
        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        float clampedY = Mathf.Clamp(transform.position.y, minY, maxY);

        // Set the clamped position
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }
}
