using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audiomixer;

    [Header("Volume sliders")]
	public Slider volumeSlider;
    public Slider SFXvolumeSlider;
    float currentVolume;
    float currentSFXVolume;

    //float currentVolumeSFX;
    //float currentMusicVolume;
    [Header("Volume sliders values")]
    private float value;

    public GameObject SettingsScreen;
    private void Start()
    {
        audiomixer.GetFloat("Music", out value);
        volumeSlider.value = value;
       
        audiomixer.GetFloat("SFXvolume", out value);
       SFXvolumeSlider.value = value;
    }

    public void SetBackgroundMusic(float volume)
    {
        audiomixer.SetFloat("Music", volume);       
        currentVolume = volume;                            //current volume is equal to the selected volume value  
    }
    public void SetSFXVolume(float volume)
    {
        audiomixer.SetFloat("SFXvolume", volume);
        currentSFXVolume = volume;                      //current volume is equal to the selected volume value
    }

    public void SaveSettings()
    {

		SettingsScreen.SetActive(false);          //close the setting screen
	}

}
