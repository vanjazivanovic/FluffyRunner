using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHoverEffect : MonoBehaviour,
    IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 originalScale;

    [Header("Hover Settings")]
    public float hoverScale = 1.08f;   // koliko se dugme uveća
    public float speed = 10f;          // brzina animacije

    private bool isHovering = false;

    void Start()
    {
        // zapamti originalnu veličinu dugmeta
        originalScale = transform.localScale;
    }

    void Update()
    {
        // ciljna skala 
        Vector3 targetScale = isHovering
            ? originalScale * hoverScale
            : originalScale;

        // smooth prelaz
        transform.localScale = Vector3.Lerp(
            transform.localScale,
            targetScale,
            Time.deltaTime * speed
        );
    }

    // kada miš uđe na dugme
    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovering = true;
    }

    // kada miš izađe sa dugmeta
    public void OnPointerExit(PointerEventData eventData)
    {
        isHovering = false;
    }
}
