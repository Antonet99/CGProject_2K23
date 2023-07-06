using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class SelectAndPlayTimeline : MonoBehaviour
{
    public PlayableDirector[] directors;
    private int avatarSelected;
    public GameObject[] player;
     private bool timelinePlaying;

     private void Start()
    {
        avatarSelected=PlayerPrefs.GetInt("avatarSelected");
        if (avatarSelected==0)
        {
            StartTimeline(directors[0]);
        }
        else
        {
            StartTimeline(directors[1]);
        }
    }

    private void StartTimeline(PlayableDirector timeline)
    {
        timeline.stopped += OnTimelineStopped;
        timeline.Play();
        timelinePlaying = true;
    }

     private void Update()
    {
        if (timelinePlaying)
        {
            if (directors[0].state != PlayState.Playing)
            {
                OnTimelineStopped(directors[0]);
            }
            if(directors[1].state != PlayState.Playing)
            {
                OnTimelineStopped(directors[1]);
            }
        }
    }

    private void OnTimelineStopped(PlayableDirector director)
    {
        // Code to return to the game when the timeline is ended
        Debug.Log("Timeline stopped");
        SceneManager.LoadScene(2);
    }
}
