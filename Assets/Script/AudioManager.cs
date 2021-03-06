﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour {

    Slider slider;
    public AudioMixer audioMixer;
    public float audioVol;

    public void Start()
    {
        slider = GetComponent<Slider>();
    }

    public void SetMasterVolume() 
    {
        if (slider.value <= -30)
        {
            slider.value = -80;
        }
        audioMixer.SetFloat("MasterVolume",slider.value);
    }

    public void SetMusicVolume() 
    {
        if (slider.value <= -30)
        {
            slider.value = -80;
        }
        audioMixer.SetFloat("MusicVolume", slider.value);
    }

    public void SetSoundEffectVolume()
    {
        if (slider.value <= -30)
        {
            slider.value = -80;
        }
        audioMixer.SetFloat("SoundEffectVolume",slider.value);
    }
}
