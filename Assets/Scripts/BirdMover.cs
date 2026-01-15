using UnityEngine;

public class BirdMover : MonoBehaviour
{
    [Tooltip("Brzina ptice ulevo (ka psu).")]
    public float speed = 6f;

    [Tooltip("Koliko daleko iza kamere da se uništi ptica.")]
    public float destroyX = -25f;

    void Update()
    {
        // ptica ide ulevo (ka kucetu)
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        // ciscenje da ne ostaju clone-ovi zauvek
        if (transform.position.x < destroyX)
            Destroy(gameObject);
    }
}

