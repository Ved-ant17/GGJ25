using UnityEngine;

public class BubbleFromMouth : MonoBehaviour
{
    [Header("References")]
    public Animator bubbleAnimator;  // Reference to the Animator component for the bubble
    public GameObject bubble;        // The bubble GameObject
    public float triggerYPosition = 5f;  // Y position at which the bubble animation is triggered
    public Transform crab;           // The crab (frog) object to track

    private bool bubbleTriggered = false; // Flag to track if the animation has been triggered

    private void Start()
    {
        // Make sure the bubble is initially hidden
      //  bubble.SetActive(false);  // Hide the bubble at the start
    }

    private void Update()
    {
        // Check crab's position on Y-axis
        if (!bubbleTriggered && crab.position.y <= triggerYPosition)
        {
            // Trigger the bubble animation when crab reaches the certain Y position
            TriggerBubbleAnimation();
        }
    }

    void TriggerBubbleAnimation()
    {
        // Show the bubble (enable it)
        bubble.SetActive(true);

        // Trigger the bubble animation (e.g., scaling or movement)
        if (bubbleAnimator != null)
        {
            bubbleAnimator.SetTrigger("BubblePopped");  // Assuming you have set up a "BubblePopped" trigger in Animator
        }

        // Set the flag to prevent re-triggering
        bubbleTriggered = true;
    }
}