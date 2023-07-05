using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSelection : MonoBehaviour
{
    [SerializeField]
    public GameObject avatar, selection;
    private int avatarSelected;
    public GameObject[] avatarModels;
    private Animator animator;
    [SerializeField]
    private Avatar[] _avatar;
    public bool isBlocking, isWinner;
    

    //Start is called before the first frame update
    void Start()
    {
        isBlocking=false;
        isWinner=false;
        avatarSelected = PlayerPrefs.HasKey("avatarSelected") ? PlayerPrefs.GetInt("avatarSelected") : 0;
        avatar=Instantiate(avatarModels[avatarSelected],transform.position,transform.rotation) as GameObject;
        UpdateAvatar(avatarSelected);
    }
    
    //Function to go to the next avatar (called when pressing next button)
    public void NextAvatar()
    {
        avatarSelected++;
        //check if we have reached the end of the avatar array
        if (avatarSelected >= avatarModels.Length)
        {
            avatarSelected = 0;
        }
        UpdateAvatar(avatarSelected);
        Save();
    }

    //Function to go to the previous avatar (called when pressing previous button)
    public void PreviousAvatar()
    {
        avatarSelected--;
        //check if we have reached the end of the avatar array
        if (avatarSelected < 0)
        {
            avatarSelected = avatarModels.Length-1;
        }
        UpdateAvatar(avatarSelected);
        Save();
    }

    //Function to update the avatar model
    private void UpdateAvatar(int avatarSelected)
    {
        GameObject thisModel = Instantiate(avatarModels[avatarSelected],transform.position,transform.rotation) as GameObject;
        Destroy(avatar);
        thisModel.transform.parent = transform;
        thisModel.transform.localScale=new Vector3(0.46f,0.46f,0.46f);
        avatar = thisModel;
        animator = GetComponent<Animator>();
        animator.avatar = _avatar[avatarSelected];
        animator.Play("Idle Walk Run Blend");
    }

    private void Save()
    {
        PlayerPrefs.SetInt("avatarSelected", avatarSelected);
    }

    public void ChangeScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
}
