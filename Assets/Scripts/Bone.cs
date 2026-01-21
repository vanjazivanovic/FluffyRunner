using UnityEngine;

public class Bone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // provara da li je pas dosao do kosti
        {
            // Poziva CollectBone na pasu
            BoneCollector collector = other.GetComponent<BoneCollector>();
            if (collector != null)
            {
                collector.CollectBone();// poziva je i tamo povecava broj skupljenih kosti i spawnuje novu kost
            }

            Destroy(gameObject); // unistava kost
        }
    }
}
