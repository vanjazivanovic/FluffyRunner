using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public float speed = 5f;
    public float width = 63.29f; // TAČNA širina slike

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x <= -width)
        {
            transform.position += Vector3.right * width;
        }
    }
}