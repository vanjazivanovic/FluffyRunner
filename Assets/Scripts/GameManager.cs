using UnityEngine;
using UnityEngine.SceneManagement;




public class GameManager : MonoBehaviour
{
    
    [Header("Backgrounds")]
    public GameObject cityBackground;
    public GameObject forestBackground;
    public GameObject beachBackground;

    [Header("Obstacle Spawners (dodeli u Inspector-u)")]
    public GameObject cityObstacleSpawner;   // spawnuje kante
    public GameObject forestObstacleSpawner; // spawnuje prepreke u šumi
    public GameObject beachObstacleSpawner;  // spawnuje prepreke na plaži

    [Header("References")]
    public PlayerController player;
    public BoneCollector boneCollector;

    [Header("Level goals (po nivou, jer resetuješ bonesCollected)")]
    public int[] bonesPerLevel = { 10, 20, 999 };
   

    [Header("Game Over UI")]
    public GameObject gameOverPanel;

    [Header("Canvases")]
    public GameObject mainMenuCanvas;
    public GameObject gameplayCanvas;

    private int currentLevel = 0;
    public int CurrentLevel => currentLevel;

    private bool gameFinished = false;

    void Start()
    {
        currentLevel = 0;
        gameFinished = false;

        boneCollector.bonesCollected = 0;
        boneCollector.bonesToWin = bonesPerLevel[currentLevel];
        boneCollector.UpdateBonesUI();

        UpdateBackground(); // pali grad
        UpdateSpawners();// pali grad spawner

        // spawn prve kosti
        if (boneCollector.spawner != null)
            boneCollector.spawner.SpawnBone();


        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);

        Time.timeScale = 1f;

       

    }

    void Update()
    {
        if (gameFinished) return;

        if (boneCollector.bonesCollected >= bonesPerLevel[currentLevel])
        {
            NextLevel(); // ako su sakupio dovoljno predji na sl nivo
            return; // zaštita da ne preskoči nivo u istom frame-u
        }
    }

    void NextLevel()
    {
        currentLevel++;

        // Ako nema više nivoa
        if (currentLevel >= bonesPerLevel.Length)
        {
            FinishGame();
            return;
        }

        // Resetuje broj skupljenih kostiju za novi nivo
        boneCollector.bonesCollected = 0;

        // Postavlja novi cilj
        boneCollector.bonesToWin = bonesPerLevel[currentLevel];

        
        boneCollector.UpdateBonesUI();

        // Obriši stare prepreke
        foreach (var o in GameObject.FindGameObjectsWithTag("Obstacle"))
            Destroy(o);

        // Promeni pozadinu i upali samo odgovarajući spawner
        UpdateBackground();
        UpdateSpawners();

        // Spawn prvu kost za novi nivo
        if (boneCollector.spawner != null)
            boneCollector.spawner.SpawnBone();

        //Ubrzanje
        if (player != null)
        {
            if (currentLevel == 2)      
                player.speed += 4f;    
            else
                player.speed += 2f;    
        }
    }

    void FinishGame()
    {
        gameFinished = true;
        Debug.Log("Igra završena!");

        if (player != null)
            player.speed = 0f;

        // ugasi spawner-e
        if (cityObstacleSpawner) cityObstacleSpawner.SetActive(false);
        if (forestObstacleSpawner) forestObstacleSpawner.SetActive(false);
        if (beachObstacleSpawner) beachObstacleSpawner.SetActive(false);
    }
    public void GameOver()
    {
        if (gameFinished) return;

        gameFinished = true;

        Debug.Log("GAME OVER");

        // zaustavi psa
        if (player != null)
            player.speed = 0f;

        // ugasi spawner-e
        if (cityObstacleSpawner) cityObstacleSpawner.SetActive(false);
        if (forestObstacleSpawner) forestObstacleSpawner.SetActive(false);
        if (beachObstacleSpawner) beachObstacleSpawner.SetActive(false);

        // prikaži GAME OVER
        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);

        Time.timeScale = 0f; // ZAUSTAVLJA IGRU
    }

    public void BackToMainMenu()
    {
               
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // resetuje igricu
    }


    void UpdateBackground()
    {
        if (cityBackground) cityBackground.SetActive(currentLevel == 0);
        if (forestBackground) forestBackground.SetActive(currentLevel == 1);
        if (beachBackground) beachBackground.SetActive(currentLevel == 2);
    }

    void UpdateSpawners()
    {
        if (cityObstacleSpawner) cityObstacleSpawner.SetActive(currentLevel == 0);
        if (forestObstacleSpawner) forestObstacleSpawner.SetActive(currentLevel == 1);
        if (beachObstacleSpawner) beachObstacleSpawner.SetActive(currentLevel == 2);
    }

    void ResetBackgrounds()
    {
        if (cityBackground) ResetBGGroup(cityBackground.transform);
        if (forestBackground) ResetBGGroup(forestBackground.transform);
        if (beachBackground) ResetBGGroup(beachBackground.transform);
    }

    void ResetBGGroup(Transform root)
    {
        int i = 0;
        foreach (Transform t in root.GetComponentsInChildren<Transform>())
        {
            if (t == root) continue;
            var sr = t.GetComponent<SpriteRenderer>();
            if (sr == null) continue;

            float w = sr.bounds.size.x;
            t.localPosition = new Vector3(w * i, 0f, 0f);
            i++;
        }
    }
}

