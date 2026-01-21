using UnityEngine;

public class MultiBackgroundLoop : MonoBehaviour
{
    [Header("Sve pozadine za ovaj nivo")]
    public Transform[] backgrounds; 

    [Header("Brzina pozadine")]
    public float speed = 2f; // 

    [Header("Buffer za premestanje pre nego što izađe iz kamere")]
    public float buffer = 0.5f;

    void Update()
    {
     
        for (int i = 0; i < backgrounds.Length; i++)
        {
            backgrounds[i].position += Vector3.left * speed * Time.deltaTime;
        }

       
        for (int i = 0; i < backgrounds.Length; i++)
        {
            SpriteRenderer sr = backgrounds[i].GetComponent<SpriteRenderer>();
            float width = sr.bounds.size.x;

           
            float leftCameraEdge = Camera.main.transform.position.x - Camera.main.orthographicSize * Camera.main.aspect;

            if (backgrounds[i].position.x + width < leftCameraEdge + buffer)
            {
                float rightMostX = GetRightMostX();
                Vector3 newPos = backgrounds[i].position;
                newPos.x = rightMostX;
                backgrounds[i].position = newPos;
            }
        }
    }

  
    float GetRightMostX()
    {
        float maxX = backgrounds[0].position.x + backgrounds[0].GetComponent<SpriteRenderer>().bounds.size.x;
        foreach (Transform bg in backgrounds)
        {
            float rightEdge = bg.position.x + bg.GetComponent<SpriteRenderer>().bounds.size.x;
            if (rightEdge > maxX) maxX = rightEdge;
        }
        return maxX;
    }
}