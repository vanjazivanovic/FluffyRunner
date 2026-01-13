using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    public float speed = 2f; // brzina kretanja pozadine
    private float width;     // širina sprite-a
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
        width = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        // Pomeraj pozadinu ulevo
        transform.position += Vector3.left * speed * Time.deltaTime;

        // Ako je pozadina potpuno iza kamere, premesti je na kraj
        if (transform.position.x <= startPos.x - width)
        {
            Vector3 newPos = transform.position;
            newPos.x += width * 3; // 3 = broj slika u ciklusu
            transform.position = newPos;
        }
    }
}