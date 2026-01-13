using UnityEngine;

public class DogJump: MonoBehaviour
{
    public float jumpForce = 8f;

    private Rigidbody2D rb;
    private float fixedX;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        fixedX = transform.position.x; 
    }

    void Update()
    {
       
        transform.position = new Vector3(fixedX, transform.position.y, transform.position.z);

       
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }
}
