using UnityEngine;
using TMPro;

public class MenuController : MonoBehaviour
{
    public TMP_InputField dogNameInput;
    public GameObject gameplay;
    


    public static string DogName; // čuvamo ime psa

    public void OnStartGame()
    {
        DogName = dogNameInput.text;

        gameplay.SetActive(true);
        gameObject.SetActive(false);
    }
}
