using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public Transform[] spawnPoints;
    public float spawnInterval = 3f;
    public int maxActiveObstacles = 2;

    [Range(0f, 1f)]
    public float spawnChance = 0.4f;

    public GameManager gameManager;
    public BoneCollector boneCollector;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnObstacleLoop), 0f, spawnInterval);
    }

    void SpawnObstacleLoop()
    {
        if (gameManager == null || boneCollector == null) return;
        if (gameManager.CurrentLevel != 0) return;
        if (boneCollector.bonesCollected >= 10) return;

        int currentObstacles = GameObject.FindGameObjectsWithTag("Obstacle").Length;

        if (currentObstacles < maxActiveObstacles)
        {
            if (Random.value > spawnChance) return;
            SpawnObstacle();
        }
    }

    void SpawnObstacle()
    {
        if (spawnPoints.Length == 0 || obstaclePrefab == null) return;

        Transform spawnPoint =
            spawnPoints[Random.Range(0, spawnPoints.Length)];

        GameObject obstacle = Instantiate(
            obstaclePrefab,
            spawnPoint.position,
            Quaternion.identity
        );
    }
}

