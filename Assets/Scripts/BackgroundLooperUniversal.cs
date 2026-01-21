using UnityEngine;

public class BackgroundLooperUniversal : MonoBehaviour
{
    public Transform[] backgrounds; // ovo je za sve tri pozadine 
    public float speed = 2f;
    public float buffer = 0.5f; // sprecava da se vidi razmak izmedju slika
    public Camera referenceCamera; 

    void Update()
    {
        for (int i = 0; i < backgrounds.Length; i++) // pomeranje ulevo 
        {
            backgrounds[i].position += Vector3.left * speed * Time.deltaTime;
        }

        for (int i = 0; i < backgrounds.Length; i++)
        {
            SpriteRenderer sr = backgrounds[i].GetComponent<SpriteRenderer>(); 
            float width = sr.sprite.bounds.size.x * backgrounds[i].localScale.x; // sirina  slike


            float leftCameraEdge = referenceCamera.transform.position.x - referenceCamera.orthographicSize * referenceCamera.aspect; // leva ivica kamere

            if (backgrounds[i].position.x + width < leftCameraEdge + buffer) // ako je slika izasla iz kamere celom srinom 
            {
                float rightMostX = GetRightMostX(); // poslednja pozadina, tj ona najdesnija 
                Vector3 newPos = backgrounds[i].position;
                newPos.x = rightMostX;
                backgrounds[i].position = newPos; // poz koja je izasla iz kamere teleportuje se iza poslednje
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
        }// trazi najdesniju 

        return maxX; // vraca gde treba da sw stavi slika
    }
}
