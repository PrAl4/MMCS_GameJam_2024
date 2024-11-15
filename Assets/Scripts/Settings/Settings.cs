using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField]
    SettingsData settingsData;

    [SerializeField]
    AudioMixer audioMixer;
    const string volumeString = "Volume";

    [SerializeField]
    Slider volumeSlider;


    private void Start()
    {
        audioMixer.SetFloat(volumeString, Mathf.Log10(settingsData.volume) * 20);
        volumeSlider.value = settingsData.volume;
    }

    public void SetVolume(float value) 
    {
        settingsData.volume = value;
        audioMixer.SetFloat(volumeString, Mathf.Log10(value) * 20);
    }
}
