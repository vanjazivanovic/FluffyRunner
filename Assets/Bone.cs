using UnityEngine;

public class Bone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Poziva CollectBone na pasu
            BoneCollector collector = other.GetComponent<BoneCollector>();
            if (collector != null)
            {
                collector.CollectBone();
            }

            Destroy(gameObject);
        }
    }
}
