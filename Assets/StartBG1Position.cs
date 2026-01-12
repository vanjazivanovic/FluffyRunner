using UnityEngine;

public class StartBGPosition : MonoBehaviour
{
    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        // Lijeva ivica kamere
        float leftEdge = Camera.main.transform.position.x - Camera.main.orthographicSize * Camera.main.aspect;

        // Postavi BG1 tako da levi rub po?inje na levoj ivici kamere
        transform.position = new Vector3(leftEdge, transform.position.y, transform.position.z);
    }
}
