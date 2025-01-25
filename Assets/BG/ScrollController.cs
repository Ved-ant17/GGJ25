using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollScroller : MonoBehaviour
{
    // Speed at which the photo moves downward
    public float scrollSpeed = -2f;

    // Optional limit for stopping the movement (Y position)
    public float stopAtY = -10f;

    void Update()
    {
        // Move the photo downward
        transform.Translate(Vector3.down * scrollSpeed * Time.deltaTime);

        // Stop the movement if it reaches the stop position
        if (transform.position.y <= stopAtY)
        {
            scrollSpeed = 0f; // Stop the movement
        }
    }
}