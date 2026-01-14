using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject cityBackground;
    public GameObject forestBackground;
    public GameObject beachBackground;

    public PlayerController player;
    public BoneCollector boneCollector;

    public int[] bonesPerLevel = { 10, 20, 30 }; // ciljevi po nivou
    private int currentLevel = 0;
    public int CurrentLevel => currentLevel;


    void Start()
    {
        boneCollector.bonesToWin = bonesPerLevel[currentLevel];
        UpdateBackground();
    }

    void Update()
    {
        if (boneCollector.bonesCollected >= bonesPerLevel[currentLevel])
        {
            NextLevel();
        }
    }

    void NextLevel()
    {
        currentLevel++;

        if (currentLevel >= bonesPerLevel.Length)
        {
            // Kraj igre
            Debug.Log("Igra završena!");
            player.speed = 0f;
            return;
        }

        // Resetuje broj skupljenih kostiju za novi nivo
        boneCollector.bonesCollected = 0;

        // Postavlja novi cilj za trenutni nivo
        boneCollector.bonesToWin = bonesPerLevel[currentLevel];

        // Ažurira tekst
        boneCollector.UpdateBonesUI();

        // Spawn-uje prvu kost za novi nivo
        boneCollector.spawner.SpawnBone();

        // Menja pozadinu
        UpdateBackground();
        foreach (var o in GameObject.FindGameObjectsWithTag("Obstacle"))
            Destroy(o);

        // Ubrzava psa
        player.speed += 2f;
    }

    void UpdateBackground()
    {
        cityBackground.SetActive(currentLevel == 0);
        forestBackground.SetActive(currentLevel == 1);
        beachBackground.SetActive(currentLevel == 2);
    }
    void ResetBackgrounds()
    {
        foreach (Transform bg in cityBackground.GetComponentsInChildren<Transform>())
            bg.localPosition = new Vector3(bg.GetComponent<SpriteRenderer>().bounds.size.x * bg.GetSiblingIndex(), 0f, 0f);

        foreach (Transform bg in forestBackground.GetComponentsInChildren<Transform>())
            bg.localPosition = new Vector3(bg.GetComponent<SpriteRenderer>().bounds.size.x * bg.GetSiblingIndex(), 0f, 0f);

        foreach (Transform bg in beachBackground.GetComponentsInChildren<Transform>())
            bg.localPosition = new Vector3(bg.GetComponent<SpriteRenderer>().bounds.size.x * bg.GetSiblingIndex(), 0f, 0f);
    }
}