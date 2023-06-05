using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class MusicOptions : MonoBehaviour
{
    public AudioMixer mixer;
    public TMP_Text masterLabel, musicLabel, sfxLabel;
    public Slider masterSlider, musicSlider, sfxSlider;
    public GameObject selection,options,avatar;

   
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

    public void SetVisibleMenu(){
        selection.SetActive(false);
        avatar.SetActive(false);
        options.SetActive(true);
    }
        public void CloseMenu(){
        options.SetActive(false);
        selection.SetActive(true);
        avatar.SetActive(true);
    }
}
