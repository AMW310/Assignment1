using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance = null;

    public AudioSource SfxSource;
    public AudioSource MusicSource;

    private void Awake()
    {
        // If there is not already an instance of SoundManager, set it to this.
        if (Instance == null)
        {
            Instance = this;
        }
        //If an instance already exists, destroy whatever this object is to enforce the singleton.
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        DontDestroyOnLoad(gameObject);
    }
    public void Play(AudioClip clip)
    {
        SfxSource.clip = clip;
        SfxSource.Play();
    }
    public void PlayMusic(AudioClip clip)
    {
        SfxSource.clip = clip;
        SfxSource.Play();
    }
}
