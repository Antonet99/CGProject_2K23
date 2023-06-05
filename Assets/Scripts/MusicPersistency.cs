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
        if(PlayerPrefs.HasKey("MusicVol"))
        {
            mixer.SetFloat("MusicVol",PlayerPrefs.GetFloat("MusicVol"));
        }
        if(PlayerPrefs.HasKey("SFXVol"))
        {
            mixer.SetFloat("SFXVol",PlayerPrefs.GetFloat("SFXVol"));
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