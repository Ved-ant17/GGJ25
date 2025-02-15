using UnityEngine;
using System.Collections;

public class ShipAnimationController : MonoBehaviour
{
    [Header("GameObject Reference")]
    public GameObject targetObject; // Reference to the GameObject with the components
    public Animator shipAnimator;   // Reference to the ship's Animator
    public Transform bgTransform;  // Reference to the moving background
    public float bgFreezePoint = -5f; // The Y position of the background where animation freezes
    public string animationStateName = "BrokenState"; // Animation state to control
    public float freezeTime = 2f;  // Time in seconds to freeze animation

    private bool animationFrozen = false;
    [SerializeField] private GameObject woodenLog;
    void Update()
    {
        // Check if the background has reached the freeze point
        if (!animationFrozen && bgTransform.position.y <= bgFreezePoint)
        {
            FreezeAnimation();
            animationFrozen = true;
        }

        if (bgTransform.position.y <= bgFreezePoint - 10f)
        {

            StartCoroutine(DisableLog());
        }
    }

    void FreezeAnimation()
    {
        Debug.Log("animation freezed");
        // Set the Animator to the specific frame (time)
        shipAnimator.Play(animationStateName, 0, freezeTime / shipAnimator.GetCurrentAnimatorStateInfo(0).length);

        // Pause the Animator
        shipAnimator.speed = 0f;
    }

    public IEnumerator DisableLog()
    {
        woodenLog.SetActive(false);
        yield return new WaitForSeconds(0f);
    }
    public void EnableComponentsOnTrigger()
    {
        if (targetObject != null)
        {
            // Get the SpriteRenderer component
            SpriteRenderer spriteRenderer = targetObject.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.enabled = true; // Enable the SpriteRenderer
                Debug.Log("SpriteRenderer enabled on " + targetObject.name);
            }
            else
            {
                Debug.LogError("SpriteRenderer not found on " + targetObject.name);
            }

            // Get the Rigidbody2D component
            Rigidbody2D rigidbody2D = targetObject.GetComponent<Rigidbody2D>();
            if (rigidbody2D != null)
            {
                rigidbody2D.simulated = true; // Enable Rigidbody2D simulation
                Debug.Log("Rigidbody2D simulation enabled on " + targetObject.name);
            }
            else
            {
                Debug.LogError("Rigidbody2D not found on " + targetObject.name);
            }
        }
        else
        {
            Debug.LogError("Target GameObject is not assigned.");
        }
    }
}
