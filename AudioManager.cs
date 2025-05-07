using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    AudioSource music;
    public AudioClip titleMusic;
    public AudioClip gameMusic;
    void Awake()
    {
        music = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void PlayTitle()
    {
        music.clip = titleMusic;
        music.loop = true;
        music.Play();
    }
    public void PlayGame()
    {
        music.clip = gameMusic;
        music.loop = true;
        music.Play();
    }
    public void StopAudio()
    {
        music.Stop();
    }

}
