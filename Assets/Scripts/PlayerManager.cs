using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject playerAvatar;
    private int selectedAvatar=0;
    public GameObject[] avatarModels;
     void Start()
    {
        if(!PlayerPrefs.HasKey("avatarSelected"))
        {
            selectedAvatar=0;
            playerAvatar = Instantiate(avatarModels[0],Vector3.zero, Quaternion.identity) as GameObject;
            //playerAvatar = Instantiate(avatarModels[0],new Vector3(-5.7f,1.02002f,0), Quaternion.identity) as GameObject;
            playerAvatar.transform.parent=transform;
            playerAvatar.transform.localScale=new Vector3(1,1,1);
        }
        else
        {
            Load();
            playerAvatar = Instantiate(avatarModels[selectedAvatar],Vector3.zero, Quaternion.identity) as GameObject;
            playerAvatar.transform.parent=transform;
            playerAvatar.transform.localScale=new Vector3(1,1,1);
        }
        UpdateAvatar(selectedAvatar);
    }
    private void UpdateAvatar(int selectedAvatar)
    {
        GameObject thisModel = Instantiate(avatarModels[selectedAvatar],transform.position,transform.rotation) as GameObject;
        Destroy(playerAvatar);
        thisModel.transform.parent = transform;
        thisModel.transform.localScale=new Vector3(1,1,1);
        playerAvatar = thisModel;
    }
    private void Load()
    {
        selectedAvatar=PlayerPrefs.GetInt("avatarSelected");
    }
}
