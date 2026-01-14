using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private bool isStopped = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isStopped) return;

        rb.linearVelocity = new Vector2(speed, rb.linearVelocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            StopPlayer();
        }
    }

    void StopPlayer()
    {
        speed = 0f;
        rb.linearVelocity = Vector2.zero;
        isStopped = true;

        Debug.Log("Pas je udario prepreku i stao!");
    }
}

