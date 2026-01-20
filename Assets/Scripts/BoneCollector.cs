using UnityEngine;
using TMPro;

public class BoneCollector : MonoBehaviour
{
    public TMP_Text bonesText;
    public int bonesCollected = 0;
    public int bonesToWin;  // ovo će nam menjati GameManager po nivou
    public BoneSpawner spawner;

    void Start()
    {
        bonesText.gameObject.SetActive(true);
        UpdateBonesUI();

        if (spawner != null)
        {
            spawner.collector = this;   // dodaj ovu liniju
            spawner.SpawnBone();        // ovo već imaš
        }
    }



    public void CollectBone()
    {
        bonesCollected++;
        UpdateBonesUI();
        spawner.SpawnBone();
    }

    public void UpdateBonesUI()
    {
        bonesText.text = "Score: " + bonesCollected + "/" + bonesToWin;
    }
}