using UnityEngine;

public class SubmarineWithMovingBG : MonoBehaviour
{
    public GameObject submarine;          // Submarine object (child of the background)
    public float moveSpeed = 2f;          // Horizontal movement speed of the submarine
    public float wobbleAmplitude = 0.5f; // Height of the wobble effect
    public float wobbleFrequency = 2f;   // Speed of the wobble effect

    private Vector3 initialLocalPosition; // Submarine's initial local position

    void Start()
    {
        // Save the submarine's initial local position
        if (submarine != null)
        {
            initialLocalPosition = submarine.transform.localPosition;
        }
    }

    void Update()
    {
        if (submarine != null)
        {
            // Calculate horizontal movement
            float horizontalMovement = moveSpeed * Time.time;

            // Calculate vertical wobble using a sine wave
            float verticalWobble = Mathf.Sin(Time.time * wobbleFrequency) * wobbleAmplitude;

            // Update the submarine's local position
            submarine.transform.localPosition = new Vector3(
                initialLocalPosition.x + horizontalMovement, // Move horizontally
                initialLocalPosition.y + verticalWobble,     // Wobble vertically
                initialLocalPosition.z                      // Keep the same depth
            );
        }
    }
}
