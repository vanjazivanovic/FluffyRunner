using UnityEngine;
using UnityEngine.Video;

public class IntroController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public GameObject menuUI; 
    public MusicController musicController;
    public GameObject scoreText; // dodaj ovo polje

    void Start()
    {
        menuUI.SetActive(false);
        scoreText.SetActive(false); // sakrij score na startu

        videoPlayer.loopPointReached += OnIntroFinished;
    }

    void OnIntroFinished(VideoPlayer vp)
    {
        menuUI.SetActive(true);
        scoreText.SetActive(false); // uključi score
        gameObject.SetActive(false);

        if (musicController != null)
            musicController.PlayMusic();
    }
}


