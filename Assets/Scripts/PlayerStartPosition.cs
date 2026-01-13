using UnityEngine;

public class PlayerStartPosition : MonoBehaviour
{
    public Transform ground;
    public float offset = 0.0f;

    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();


        Vector3 startPos = transform.position;
        startPos.y = ground.position.y + offset;
        rb.position = startPos;
        rb.linearVelocity = Vector2.zero;
    }
}
