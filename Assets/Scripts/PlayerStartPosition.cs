using UnityEngine;

public class PlayerStartPosition : MonoBehaviour
{
    public Transform ground; // referenca na pod
    public float offset = 0.0f;// mali razmak iznad poda

    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();


        Vector3 startPos = transform.position; // trenutna poz psa
        startPos.y = ground.position.y + offset;// stavlja y iznad poda
        rb.position = startPos; // stavlja psa na tu poz
        rb.linearVelocity = Vector2.zero;// da se ne krece
    }
}
