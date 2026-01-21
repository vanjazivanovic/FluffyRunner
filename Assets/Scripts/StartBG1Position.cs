using UnityEngine;

public class StartBGPosition : MonoBehaviour
{
    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();

       
        float leftEdge = Camera.main.transform.position.x - Camera.main.orthographicSize * Camera.main.aspect;

       
        transform.position = new Vector3(leftEdge, transform.position.y, transform.position.z);
    }
}
