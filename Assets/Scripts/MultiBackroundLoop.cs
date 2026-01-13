using UnityEngine;

public class MultiBackgroundLoop : MonoBehaviour
{
    [Header("Sve pozadine za ovaj nivo")]
    public Transform[] backgrounds; // BG1, BG2, BG3

    [Header("Brzina pozadine")]
    public float speed = 2f; // možeš promeniti za svaki nivo u Inspectoru

    [Header("Buffer za premestanje pre nego što izađe iz kamere")]
    public float buffer = 0.5f;

    void Update()
    {
        // 1️⃣ Pomeraj sve pozadine ulevo
        for (int i = 0; i < backgrounds.Length; i++)
        {
            backgrounds[i].position += Vector3.left * speed * Time.deltaTime;
        }

        // 2️⃣ Proveri da li je neka pozadina iza kamere i premesti je na kraj
        for (int i = 0; i < backgrounds.Length; i++)
        {
            SpriteRenderer sr = backgrounds[i].GetComponent<SpriteRenderer>();
            float width = sr.bounds.size.x;

            // Levi rub kamere
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

    // 3️⃣ Pronađi desnu ivicu najdesnije pozadine
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