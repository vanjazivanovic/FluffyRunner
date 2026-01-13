using UnityEngine;

public class BackgroundLooperUniversal : MonoBehaviour
{
    public Transform[] backgrounds;
    public float speed = 2f;
    public float buffer = 0.5f;
    public Camera referenceCamera; // Dodaj ovo!

    void Update()
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            backgrounds[i].position += Vector3.left * speed * Time.deltaTime;
        }

        for (int i = 0; i < backgrounds.Length; i++)
        {
            SpriteRenderer sr = backgrounds[i].GetComponent<SpriteRenderer>();
            float width = sr.sprite.bounds.size.x * backgrounds[i].localScale.x;


            float leftCameraEdge = referenceCamera.transform.position.x - referenceCamera.orthographicSize * referenceCamera.aspect;

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
        float maxX = backgrounds[0].position.x + backgrounds[0].GetComponent<SpriteRenderer>().sprite.bounds.size.x * backgrounds[0].localScale.x;
        foreach (Transform bg in backgrounds)
        {
            float rightEdge = bg.position.x + bg.GetComponent<SpriteRenderer>().sprite.bounds.size.x * bg.localScale.x;
            if (rightEdge > maxX) maxX = rightEdge;
        }

        return maxX;
    }
}
