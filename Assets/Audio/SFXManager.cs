using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public enum SFXType { }
public class SFXManager : MonoBehaviour {

    public static SFXManager instance;
    public AudioSource musicAdioSource;
    private AudioSource sfxAudioSource;
    public AudioClip[] sfxCollection;

    public AudioMixer gameAudioMixer;

    public Slider volumenSlider;
    public Slider sfxSlider;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    void Start () {
        sfxAudioSource = GetComponent<AudioSource>();
	}
	
	void Update () {
        gameAudioMixer.SetFloat("MusicVolumen", volumenSlider.value);
        gameAudioMixer.SetFloat("SFXVolumen", sfxSlider.value);

        if (volumenSlider.value == -20)
            musicAdioSource.mute = true;
        else
            musicAdioSource.mute = false;

        if (sfxSlider.value == -20)
            sfxAudioSource.mute = true;
        else
            sfxAudioSource.mute = false;
	}

    public void PlaySFX(SFXType sfxType)
    {
        switch(sfxType)
        {

        }
    }
}
