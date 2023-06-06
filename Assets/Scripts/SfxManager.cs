using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SfxManager : MonoBehaviour
{
    AudioSource source;
    public AudioClip femalepunch, femalekick, femalewinning,femaleyes,malepunch,malekick,malewinning;
    float delayTemp=0.4f;
    float delay;
    // Start is called before the first frame update
    void Start()
    {
       source=this.GetComponent<AudioSource>(); 
       delay=delayTemp;
    }
    public void FemalePunch(){
        source.clip=femalepunch;
        source.Play();
    }
    public void FemaleKick(){
        source.clip=femalekick;
        source.Play();
        //source.clip=femaleyes;
        //source.Play();
    }
    public void FemaleWinning(){
        source.clip=femalewinning;
        source.Play();
    }

}
