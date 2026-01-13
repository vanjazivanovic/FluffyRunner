using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip gameMusic; // ovo je tvoj mp3/wav fajl

    public void PlayMusic()
    {
        if (audioSource != null && gameMusic != null)
        {
            audioSource.clip = gameMusic;
            audioSource.loop = true;
            audioSource.volume = 0.4f;
            audioSource.Play();
        }
    }
}
