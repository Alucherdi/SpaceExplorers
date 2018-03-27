using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour {

    public static AudioManager instance;
    public AudioSource musicAudioSource;
    public AudioClip[] musicCollection;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);

    }
    public void MenuMusic()
    {
        musicAudioSource.clip = musicCollection[0];
        musicAudioSource.loop = true;
        musicAudioSource.Play();
    }
}
