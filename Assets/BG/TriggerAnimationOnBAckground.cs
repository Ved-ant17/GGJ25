using UnityEngine;

public class TriggerAnimationOnBackground : MonoBehaviour
{
    [Header("Background and Trigger Settings")]
    public Transform background;       // Reference to the background Transform
    public float triggerYPosition;     // The Y-coordinate where the animation starts

    [Header("Animation Settings")]
    public Animator targetAnimator;    // Animator for the object
    public string animationTrigger;    // Trigger parameter name in Animator

    private bool animationTriggered = false; // To ensure the animation is triggered only once

    void Update()
    {
        // Check if the background has reached the specified Y position
        if (!animationTriggered && background.position.y <= triggerYPosition)
        {
            StartAnimation();
        }
    }

    void StartAnimation()
    {
        animationTriggered = true; // Prevent triggering multiple times
        targetAnimator.SetTrigger(animationTrigger); // Start the animation
        //StartCoroutine(StopAnimatorAfterOneCycle());
    }

    // System.Collections.IEnumerator StopAnimatorAfterOneCycle()
    // {
    //     // Get the length of the current animation clip
    //     AnimatorClipInfo[] clipInfo = targetAnimator.GetCurrentAnimatorClipInfo(0);
    //     if (clipInfo.Length > 0)
    //     {
    //         float animationLength = clipInfo[0].clip.length;
    //         yield return new WaitForSeconds(animationLength); // Wait for the animation to complete
    //     }

    //     targetAnimator.enabled = false; // Stop the animator to freeze the animation at the final frame
    // }
}
