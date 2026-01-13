using UnityEngine;

public class BoneSpawner : MonoBehaviour
{
    public GameObject bonePrefab;
    public Transform[] spawnPoints;
    public float spawnInterval = 2f;   // koliko sekundi između pojavljivanja
    public int maxActiveBones = 3;     // maksimalan broj kostiju istovremeno
    public BoneCollector collector;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnBoneLoop), 0f, spawnInterval);
    }

    void SpawnBoneLoop()
    {
        if (collector != null && collector.bonesCollected < collector.bonesToWin)
        {
            // proveri koliko kostiju trenutno postoji
            int currentBones = GameObject.FindGameObjectsWithTag("Bone").Length;

            if (currentBones < maxActiveBones)
            {
                SpawnBone();
            }
        }
    }

    public void SpawnBone()
    {
        int index = Random.Range(0, spawnPoints.Length);
        Vector3 spawnPos = spawnPoints[index].position;
        Instantiate(bonePrefab, spawnPos, Quaternion.identity);
    }
}