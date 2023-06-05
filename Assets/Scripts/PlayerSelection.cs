using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerSelection : MonoBehaviour
{
    [SerializeField]
    public GameObject avatar;
    private int avatarSelected=0;
    public GameObject[] avatarModels;
    private Animator animator;
    public RuntimeAnimatorController[] animatorController;
    public Avatar[] avatarAnimation;

    // Start is called before the first frame update
    void Start()
    {
         animator = GetComponent<Animator>();
        if(!PlayerPrefs.HasKey("avatarSelected"))
        {
            avatarSelected=0;
            avatar = Instantiate(avatarModels[0],new Vector3(0f,-3f,0f), new Quaternion(0f,180f,0,0)) as GameObject;
            avatar.transform.parent=transform;
            avatar.transform.localScale=new Vector3(0.46f,0.46f,0.46f);
            // Set the animator controller
            animator.runtimeAnimatorController = animatorController[avatarSelected];
            // Set the avatar for animation
            animator.avatar = avatarAnimation[avatarSelected];
            animator.Play("selection");
        }
        else
        {
            Load();
            avatar = Instantiate(avatarModels[avatarSelected],new Vector3(0f,-3f,0f), new Quaternion(0f,180f,0,0)) as GameObject;
            avatar.transform.parent=transform;
            avatar.transform.localScale=new Vector3(0.46f,0.46f,0.46f);
            // Set the animator controller
            animator.runtimeAnimatorController = animatorController[avatarSelected];
            // Set the avatar for animation
            animator.avatar = avatarAnimation[avatarSelected];
            animator.Play("selection");
        }
        UpdateAvatar(avatarSelected);
    }
    /*void Update()
    {
        avatar.transform.Rotate(0f, 15*Time.deltaTime, 0f);
    }*/
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
            avatarSelected = avatarModels.Length;
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
         // Set the animator controller
        animator.runtimeAnimatorController = animatorController[avatarSelected];
        // Set the avatar for animation
        animator.avatar = avatarAnimation[avatarSelected];
        animator.Play("selection");
    }
    private void Load()
    {
        avatarSelected=PlayerPrefs.GetInt("avatarSelected");
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

