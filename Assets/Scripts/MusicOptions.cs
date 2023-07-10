using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class MusicOptions : MonoBehaviour
{
    [Tooltip("Reference to the general mixer (the one that contains the musicMixer and the SFXMixer)")]
    public AudioMixer mixer;
    [Space(5)]
    [Header("GUI Components")]
    [Tooltip("Label that contains the number of volume of general mixer")]
    public TMP_Text masterLabel;
     [Tooltip("Label that contains the number of volume of music mixer")]
    public TMP_Text musicLabel;
     [Tooltip("Label that contains the number of volume of sfx mixer")]
    public TMP_Text sfxLabel;

    [Tooltip("Slider that dinamically change the volume of general mixer")]
    public Slider masterSlider;
    [Tooltip("Slider that dinamically change the volume of music mixer")]
    public Slider musicSlider;
    [Tooltip("Slider that dinamically change the volume of sfx mixer")]
    public Slider sfxSlider;
   
   //Start is called on the frame when a script is enabled just before
   //any of the Update methods is called the first time.
    void Start()
   {
        float vol=0f;
        mixer.GetFloat("MasterVol", out vol);
        masterSlider.value=vol;
        mixer.GetFloat("MusicVol", out vol);
        musicSlider.value=vol;
        mixer.GetFloat("SFXVol", out vol);
        sfxSlider.value=vol;

        masterLabel.text=Mathf.RoundToInt(masterSlider.value+80).ToString();
        musicLabel.text=Mathf.RoundToInt(musicSlider.value+80).ToString();
        sfxLabel.text=Mathf.RoundToInt(sfxSlider.value+80).ToString();
   }
    //This function it's called whenever we do a chenaging of the value
    //through the slider
    public void SetMasterVolume()
    {
        masterLabel.text=Mathf.RoundToInt(masterSlider.value+80).ToString();
        mixer.SetFloat("MasterVol", masterSlider.value);
        PlayerPrefs.SetFloat("MasterVol", masterSlider.value);
    }
    public void SetMusicVolume()
    {
        musicLabel.text=Mathf.RoundToInt(musicSlider.value+80).ToString();
        mixer.SetFloat("MusicVol", musicSlider.value);
        PlayerPrefs.SetFloat("MusicVol", musicSlider.value);
    }
    public void SetSFXVolume()
    {
        sfxLabel.text=Mathf.RoundToInt(sfxSlider.value+80).ToString();
        mixer.SetFloat("SFXVol", sfxSlider.value);
        PlayerPrefs.SetFloat("SFXVol", sfxSlider.value);
    }
}
