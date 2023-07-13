using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SfxManager : MonoBehaviour
{
    AudioSource source;
    public AudioClip audioPunch, audioKick, audioWinning,femaleYes;
    float delayTemp=0.4f;
    float delay;
    // Start is called before the first frame update
    void Start()
    {
       source=this.GetComponent<AudioSource>(); 
       delay=delayTemp;
    }
    public void AudioPunch(){
        source.clip=audioPunch;
        source.Play();
    }
    public void AudioKick(){
        source.clip=audioKick;
        source.Play();
        //source.clip=femaleyes;
        //source.Play();
    }
    public void AudioWinning(){
        source.clip=audioWinning;
        source.Play();
    }

}
