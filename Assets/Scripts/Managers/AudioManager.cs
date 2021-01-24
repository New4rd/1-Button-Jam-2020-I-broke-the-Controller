using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    static public AudioManager Instance;

    [SerializeField] AudioSource soundSource;
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource engineSource;


    private void Awake()
    {
        Instance = this;
    }


    private IEnumerator Start()
    {
        yield return new WaitForSecondsRealtime(2.5f);
        musicSource.Play();
    }


    public void LoadSound (string soundName, bool autoPlay = true, bool loop = false)
    {
        soundSource.clip = Resources.Load("Audio/Sounds/" + soundName) as AudioClip;
        if (autoPlay) soundSource.Play();
        soundSource.loop = loop;
    }


    public void LoadMusic (string musicName, bool autoPlay = true, bool loop = true)
    {
        musicSource.clip = Resources.Load("Audio/Musics/" + musicName) as AudioClip;
        if (autoPlay) musicSource.Play();
        musicSource.loop = loop;
    }


    public void ModifyVolume (float newVolume)
    {
        musicSource.volume = newVolume;
    }


    public void LoadEngineSound (string soundName, bool autoPlay = true, bool loop = true)
    {
        engineSource.clip = Resources.Load("Audio/Sounds/" + soundName) as AudioClip;
        if (autoPlay) engineSource.Play();
        engineSource.loop = loop;
    }


    public void UnloadEngineSound ()
    {
        engineSource.clip = null;
    }


    public void LaunchEngineSound ()
    {
        engineSource.Play();
    }


    public void PauseEngineSound ()
    {
        engineSource.Pause();
    }


    public void LoadRandomMusic ()
    {
        int r = Random.Range(0, 4);

        switch (r)
        {
            case (0): LoadMusic("Breeze"); break;
            case (1): LoadMusic("Late Night"); break;
            case (2): LoadMusic("Lyra"); break;
            case (3): LoadMusic("TM"); break;
            default: break;
        }
    }
}
