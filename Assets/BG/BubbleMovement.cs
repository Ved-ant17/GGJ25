using UnityEngine;

public class BubbleMovement : MonoBehaviour
{
    public float speed = 2f; // Speed of the bubble

    void Update()
    {
        // Move the bubble upward
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}
