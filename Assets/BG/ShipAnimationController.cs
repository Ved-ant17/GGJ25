using UnityEngine;

public class ShipAnimationController : MonoBehaviour
{
    public Animator shipAnimator;   // Reference to the ship's Animator
    public Transform bgTransform;  // Reference to the moving background
    public float bgFreezePoint = -5f; // The Y position of the background where animation freezes
    public string animationStateName = "BrokenState"; // Animation state to control
    public float freezeTime = 2f;  // Time in seconds to freeze animation

    private bool animationFrozen = false;

    void Update()
    {
        // Check if the background has reached the freeze point
        if (!animationFrozen && bgTransform.position.y <= bgFreezePoint)
        {
            FreezeAnimation();
            animationFrozen = true;
        }
    }

    void FreezeAnimation()
    {
        // Set the Animator to the specific frame (time)
        shipAnimator.Play(animationStateName, 0, freezeTime / shipAnimator.GetCurrentAnimatorStateInfo(0).length);

        // Pause the Animator
        shipAnimator.speed = 0f;
    }
}
