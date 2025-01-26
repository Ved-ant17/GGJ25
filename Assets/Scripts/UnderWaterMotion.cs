using UnityEngine;

public class UnderwaterMotion : MonoBehaviour
{
    [Header("Wobble Settings")]
    public float wobbleAmplitude = 0.1f; // Height of the wobble
    public float wobbleFrequency = 2f;  // Speed of the wobble

    [Header("Horizontal Movement Settings")]
    public float horizontalSpeed = 2f; // Speed of horizontal movement

    [Header("Player Controls")]
    public float manualSpeed = 5f; // Speed for WASD control

    [Header("Particle Effect")]
    public GameObject bubbleTrail; // Prefab for the bubble trail particle system

    private Vector3 startPosition;

    void Start()
    {
        // Store the initial position of the bubble
        startPosition = transform.position;

        // Attach the bubble trail effect
        if (bubbleTrail != null)
        {
            Instantiate(bubbleTrail, transform.position, Quaternion.identity, transform);
        }
    }

    void Update()
    {
        // Calculate the wobble effect (sinusoidal movement)
        float wobble = Mathf.Sin(Time.time * wobbleFrequency) * wobbleAmplitude;

        // Base position with wobble
        Vector3 basePosition = startPosition;
        basePosition.y += wobble;
        basePosition.x += horizontalSpeed * Time.deltaTime;

        // Handle manual movement with WASD keys
        float horizontalInput = Input.GetAxis("Horizontal"); // A/D or Left/Right
        float verticalInput = Input.GetAxis("Vertical");     // W/S or Up/Down

        Vector3 manualMovement = new Vector3(horizontalInput, verticalInput, 0f) * manualSpeed * Time.deltaTime;

        // Combine automatic motion (wobble and horizontal) with manual control
        transform.position = basePosition + manualMovement;
    }
}
