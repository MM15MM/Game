using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audiomixer;
	public Slider volumeSlider;
	float currentVolume;
	public Dropdown qualityDropdown;
    private float value;

	public GameObject SettingsScreen;

    private void Start()
    {
        audiomixer.GetFloat("volume", out value);
        volumeSlider.value = value;
    }


    public void SetVolume(float volume)
    {
        audiomixer.SetFloat("Volume", volume);
        currentVolume = volume;
    }

	public void SetQuality(int qualityIndex)
	{
		QualitySettings.SetQualityLevel(qualityIndex);
	}
	public void SaveSettings()
    {

		SettingsScreen.SetActive(false);
	}

}
