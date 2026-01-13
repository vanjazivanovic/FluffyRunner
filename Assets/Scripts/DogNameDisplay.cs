using UnityEngine;
using TMPro;

public class DogNameDisplay : MonoBehaviour
{
    private TMP_Text dogNameText;

    void Awake()
    {
        dogNameText = GetComponentInChildren<TMP_Text>();
        if (dogNameText == null)
            Debug.LogError("TMP_Text komponenta nije pronađena na DogNameHUD!");
    }

    void OnEnable()
    {
        if (dogNameText != null)
            // postavlja ime psa iz MenuController
            dogNameText.text = MenuController.DogName;
    }
}
