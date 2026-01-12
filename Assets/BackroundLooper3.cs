using UnityEngine;

public class BackgroundLooper3 : MonoBehaviour
{
    public Transform[] backgrounds; // Tvoje 3 slike
    public float speed = 2f;       // Brzina scrollovanja

    private float bgWidth;          // Širina jedne slike

    private void Start()
    {
        if (backgrounds.Length == 0) return;

        // Pretpostavljamo da su sve slike iste širine
        bgWidth = backgrounds[0].GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void Update()
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            backgrounds[i].position += Vector3.left * speed * Time.deltaTime;

            // Ako pozadina izađe van ekrana (levo), premestimo je na kraj
            if (backgrounds[i].position.x <= -bgWidth)
            {
                // Pronađi desno najdalju pozadinu
                float rightMostX = GetRightMostX();
                backgrounds[i].position = new Vector3(rightMostX + bgWidth, backgrounds[i].position.y, backgrounds[i].position.z);
            }
        }
    }

    private float GetRightMostX()
    {
        float maxX = backgrounds[0].position.x;
        foreach (Transform bg in backgrounds)
        {
            if (bg.position.x > maxX)
                maxX = bg.position.x;
        }
        return maxX;
    }
}