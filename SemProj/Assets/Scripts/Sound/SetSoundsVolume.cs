using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetSoundsVolume : MonoBehaviour
{
    [SerializeField] private AudioMixer mainMixer;

    [SerializeField] private Save save;

    private Slider[] volumeSliders;

    private void Start()
    {
        volumeSliders = save.volumeSliders;
    }

    public void SetMainVolume()
    {
        Slider mainSlider = volumeSliders[0];
        mainMixer.SetFloat("MasterVolume", Mathf.Log10(mainSlider.value) * 20f);
        mainMixer.SetFloat("MusicVolume", Mathf.Log10(mainSlider.value) * 20f);
        mainMixer.SetFloat("SoundFXVolume", Mathf.Log10(mainSlider.value) * 20f);
    }
    public void SetMusicVolume()
    {
        Slider musicSlider = volumeSliders[1];
        mainMixer.SetFloat("MusicVolume", Mathf.Log10(musicSlider.value) * 20f);
    }
    public void SetSoundFXVolume()
    {
        Slider soundFXSlider = volumeSliders[2];
        mainMixer.SetFloat("SoundFXVolume", Mathf.Log10(soundFXSlider.value) * 20f);
    }
}
