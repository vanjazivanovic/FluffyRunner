using UnityEngine;

public class UmbrellaMover : MonoBehaviour
{
    public float speed = 4f;      // brzina kretanja ulevo
    public float destroyX = -25f; // gde se uništava kad izađe sa ekrana

    void Update()
    {
        // kretanje ulevo (ka psu)
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        // uništi kad izađe sa leve strane
        if (transform.position.x < destroyX)
        {
            Destroy(gameObject);
        }
    }
}

