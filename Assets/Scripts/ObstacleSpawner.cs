using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [Header("Prefabs by theme")]
    public GameObject cityCanPrefab;              

    public GameObject[] forestObstaclePrefabs;  
    public GameObject[] beachObstaclePrefabs;     

    [Header("Spawn points")]
    public Transform[] citySpawnPoints;           

    public Transform[] forestGroundSpawnPoints;   // pečurke i ostalo na zemlji
    public Transform[] forestAirSpawnPoints;      // ptice u vazduhu

    public Transform[] beachGroundSpawnPoints;    // suncobran na pesku

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

       
        if (level == 0)
        {
           
            if (boneCollector.bonesCollected >= boneCollector.bonesToWin) return;

            SpawnFrom(cityCanPrefab, citySpawnPoints);
            return;
        }

      
        if (level == 1)
        {
            SpawnForestObstacle();
            return;
        }

       
        if (level == 2)
        {
            SpawnBeachObstacle();
            return;
        }

     
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







