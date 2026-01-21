using UnityEngine;
using TMPro;

public class BoneCollector : MonoBehaviour
{
    public TMP_Text bonesText;
    public int bonesCollected = 0;
    public int bonesToWin;  // ovo će  menjati GameManager po nivou, koliko treba za pobedu
    public BoneSpawner spawner; // ko stvara  kost

    void Start()
    {
        bonesText.gameObject.SetActive(true);
        UpdateBonesUI();

        if (spawner != null)
        {
            spawner.collector = this;   
            spawner.SpawnBone();        
        }
    }



    public void CollectBone()
    {
        bonesCollected++;
        UpdateBonesUI(); 
        spawner.SpawnBone();// nova kost
    }

    public void UpdateBonesUI()
    {
        if (FindObjectOfType<GameManager>().CurrentLevel == 2)
        {
            bonesText.text = "Score: " + bonesCollected;
        }
        else
        {
            bonesText.text = "Score: " + bonesCollected + "/" + bonesToWin;
        }
    }
}