using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadSelectedCharacter : MonoBehaviour
{
    private int avatarSelected;
    public GameObject malePlayer, femalePlayer;
    public Image playerIcon;
    public Sprite[] playerImage;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private Avatar[] _avatar;
    // Start is called before the first frame update
    void Start()
    {
        avatarSelected = PlayerPrefs.HasKey("avatarSelected") ? PlayerPrefs.GetInt("avatarSelected") : 0;
        if (avatarSelected == 0){
            femalePlayer.SetActive(false);
            malePlayer.SetActive(true);
        }
        else
        {
            malePlayer.SetActive(false);
            femalePlayer.SetActive(true);
        }
        animator.avatar = _avatar[avatarSelected];
        ChangeImage(avatarSelected);
    }

    private void ChangeImage(int avatarSelected)
    {
        playerIcon.sprite=playerImage[avatarSelected];
    }
}
