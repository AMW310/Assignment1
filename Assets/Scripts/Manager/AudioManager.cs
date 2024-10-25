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
        if (Instance == null)
        {
            Instance = this;
        }
        
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        
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
