using UnityEngine;

public class CrabBubbleEmitter : MonoBehaviour
{
    public GameObject bubblePrefab; // Assign your bubble prefab here
    public Transform emitPoint;     // Point where the bubble will spawn
    public float bubbleSpeed = 2f;  // Speed of the emitted bubble
    public float emitInterval = 3f; // Interval between bubble emissions

    private bool canEmit = true;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerBubble") && canEmit)
        {
            EmitBubble();
            StartCoroutine(EmitCooldown());
        }
    }

    void EmitBubble()
    {
        // Instantiate the bubble at the emit point
        GameObject bubble = Instantiate(bubblePrefab, emitPoint.position, Quaternion.identity);

        // Set the bubble's velocity to move upward
        Rigidbody2D rb = bubble.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.up * bubbleSpeed;
        }
    }

    System.Collections.IEnumerator EmitCooldown()
    {
        canEmit = false;
        yield return new WaitForSeconds(emitInterval);
        canEmit = true;
    }
}
