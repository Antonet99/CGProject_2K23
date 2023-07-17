using UnityEngine;
using UnityEngine.Audio;

public class MusicPersistency : MonoBehaviour
{
    private static MusicPersistency instance;

    public static MusicPersistency Instance
    {
        get { return instance; }
    }
    public AudioMixer mixer;

    void Start()
    {
        if(PlayerPrefs.HasKey("MasterVol"))
        {
            mixer.SetFloat("MasterVol",PlayerPrefs.GetFloat("MasterVol"));
        }
        else
        {
            mixer.SetFloat("MasterVol",80);
        }
        if(PlayerPrefs.HasKey("MusicVol"))
        {
            mixer.SetFloat("MusicVol",PlayerPrefs.GetFloat("MusicVol"));
        }
        else
        {
            mixer.SetFloat("MusicVol",80);
        }
        if(PlayerPrefs.HasKey("SFXVol"))
        {
            mixer.SetFloat("SFXVol",PlayerPrefs.GetFloat("SFXVol"));
        }
        else
        {
            mixer.SetFloat("SFXVol",80);
        }
        DontDestroyOnLoad(gameObject);
    }
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
    }
}