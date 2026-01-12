using UnityEngine;

public class BoneCleanup : MonoBehaviour
{
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        // leva ivica kamere
        float leftEdge = mainCamera.transform.position.x - mainCamera.orthographicSize * mainCamera.aspect;

        // ako je kost izašla levo iz vidika → uništi je
        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
    }
}