using UnityEngine;
using UnityEngine.SceneManagement;
public class SubmarineWithMovingBG : MonoBehaviour
{
    public float moveSpeed = 2f;          // Horizontal movement speed of the submarine
    public float wobbleAmplitude = 0.5f; // Height of the wobble effect
    public float wobbleFrequency = 2f;   // Speed of the wobble effect

    private Vector3 initialLocalPosition; // Submarine's initial local position
    private float elapsedTime;            // Custom timer to track time

    void Start()
    {
        // Save the submarine's initial local position
        initialLocalPosition = transform.localPosition;

        // Reset the custom timer
        elapsedTime = 0f;
    }

    void Update()
    {
        // Update the custom timer
        elapsedTime += Time.deltaTime;

        // Calculate horizontal movement
        float horizontalMovement = moveSpeed * elapsedTime;

        // Calculate vertical wobble using a sine wave
        float verticalWobble = Mathf.Sin(elapsedTime * wobbleFrequency) * wobbleAmplitude;

        // Update the submarine's local position
        transform.localPosition = new Vector3(
            initialLocalPosition.x + horizontalMovement, // Move horizontally
            initialLocalPosition.y + verticalWobble,     // Wobble vertically
            initialLocalPosition.z                      // Keep the same depth
        );
    }
    
}
