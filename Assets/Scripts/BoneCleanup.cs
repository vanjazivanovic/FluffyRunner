using UnityEngine;

public class BoneCleanup : MonoBehaviour
{
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;// uzima glavnu kameru 
    }

    void Update()
    {
        //  racuna levu ivicu kamere
        float leftEdge = mainCamera.transform.position.x - mainCamera.orthographicSize * mainCamera.aspect;

        //unisti ako je kost izašla levo iz vidika
        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
    }
}