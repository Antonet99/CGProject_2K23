using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class SelectAndPlayTimeline : MonoBehaviour
{
    public PlayableDirector[] directors;
    private int avatarSelected;
    private PlayableDirector director;
    public GameObject[] player;

    private void Awake()
    {
        avatarSelected=PlayerPrefs.GetInt("avatarSelected");
        player[avatarSelected].SetActive(true);
        director = directors[avatarSelected];
        director.stopped += OnTimelineStopped;
        director.Play();
    }

    private void OnTimelineStopped(PlayableDirector director)
    {
        SceneManager.LoadScene(2);
        // Code to return to the game when the timeline is ended
        // Add your implementation here
    }
}
