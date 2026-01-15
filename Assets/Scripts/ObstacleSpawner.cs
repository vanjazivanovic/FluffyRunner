using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [Header("Prefabs by theme")]
    public GameObject cityCanPrefab;              // City_TrashCan

    public GameObject[] forestObstaclePrefabs;    // mushroom, Forest_Bird, ...
    public GameObject[] beachObstaclePrefabs;     // Beach_Umbrella, Beach_Ball, ...

    [Header("Spawn points")]
    public Transform[] citySpawnPoints;           // CitySpawnPoint_*

    public Transform[] forestGroundSpawnPoints;   // pečurke i ostalo na zemlji
    public Transform[] forestAirSpawnPoints;      // ptice u vazduhu

    public Transform[] beachGroundSpawnPoints;    // suncobran, lopta... na pesku

    [Header("Spawn settings")]
    public float spawnInterval = 3f;
    public int maxActiveObstacles = 2;

    [Range(0f, 1f)]
    public float spawnChance = 0.4f;

    [Header("References")]
    public GameManager gameManager;
    public BoneCollector boneCollector;

    private bool isInvoking = false;

    void OnEnable()
    {
        if (!isInvoking)
        {
            InvokeRepeating(nameof(SpawnObstacleLoop), spawnInterval, spawnInterval);
            isInvoking = true;
        }
    }

    void OnDisable()
    {
        CancelInvoke(nameof(SpawnObstacleLoop));
        isInvoking = false;
    }

    void SpawnObstacleLoop()
    {
        if (gameManager == null || boneCollector == null) return;

        // max prepreka (sve zajedno)
        int currentObstacles = GameObject.FindGameObjectsWithTag("Obstacle").Length;
        if (currentObstacles >= maxActiveObstacles) return;

        // random šansa
        if (Random.value > spawnChance) return;

        int level = gameManager.CurrentLevel;

        // GRAD (0)
        if (level == 0)
        {
            // koristi cilj nivoa umesto hardkodovanog 10
            if (boneCollector.bonesCollected >= boneCollector.bonesToWin) return;

            SpawnFrom(cityCanPrefab, citySpawnPoints);
            return;
        }

        // ŠUMA (1)
        if (level == 1)
        {
            SpawnForestObstacle();
            return;
        }

        // PLAŽA (2)
        if (level == 2)
        {
            SpawnBeachObstacle();
            return;
        }

        // Ostalo: trenutno ništa
    }

    void SpawnForestObstacle()
    {
        if (forestObstaclePrefabs == null || forestObstaclePrefabs.Length == 0) return;

        GameObject prefab = forestObstaclePrefabs[Random.Range(0, forestObstaclePrefabs.Length)];
        if (prefab == null) return;

        // Ptice u vazduh, ostalo na zemlju
        if (prefab.name.Contains("Bird"))
            SpawnFrom(prefab, forestAirSpawnPoints);
        else
            SpawnFrom(prefab, forestGroundSpawnPoints);
    }

    void SpawnBeachObstacle()
    {
        if (beachObstaclePrefabs == null || beachObstaclePrefabs.Length == 0) return;

        GameObject prefab = beachObstaclePrefabs[Random.Range(0, beachObstaclePrefabs.Length)];
        if (prefab == null) return;

        SpawnFrom(prefab, beachGroundSpawnPoints);
    }

    void SpawnFrom(GameObject prefab, Transform[] points)
    {
        if (prefab == null || points == null || points.Length == 0) return;

        Transform spawnPoint = points[Random.Range(0, points.Length)];
        Instantiate(prefab, spawnPoint.position, Quaternion.identity);
    }
}







