using UnityEngine;

public class DebugWidth : MonoBehaviour
{
    void Start()
    {
        float width = GetComponent<SpriteRenderer>().bounds.size.x;
        Debug.Log("WIDTH = " + width);
    }
}