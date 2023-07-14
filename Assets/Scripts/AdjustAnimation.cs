using System.Collections;
using System.Collections.Generic;
using Etra.StarterAssets;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdjustAnimation : MonoBehaviour
{
    Animator _playerAnimator;
    GameObject WinImg, DieImg;
    void Start()
    {
        _playerAnimator = EtraCharacterMainController.Instance.modelParent.GetComponentInChildren<Animator>();
        WinImg = GameObject.Find("WinImg");
        DieImg = GameObject.Find("DieImg");
    }
    public void MoveNear(float x)
    {
        _playerAnimator.transform.position = new Vector3(_playerAnimator.transform.position.x+x, _playerAnimator.transform.position.y, _playerAnimator.transform.position.z);
    }

    public void RotateY (float y)
    {
        _playerAnimator.transform.rotation = Quaternion.Euler(_playerAnimator.transform.rotation.x, y, _playerAnimator.transform.rotation.z);
    }

    public void ChangeAllCoords (float x)
    {
        _playerAnimator.transform.position = new Vector3(x, _playerAnimator.transform.position.y, _playerAnimator.transform.position.z);
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void Win()
    {
        WinImg.SetActive(true);
    }

    public void Die()
    {
        DieImg.SetActive(true);
    }
}
