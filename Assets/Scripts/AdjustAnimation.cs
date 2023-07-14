using System.Collections;
using System.Collections.Generic;
using Etra.StarterAssets;
using UnityEngine;

public class AdjustAnimation : MonoBehaviour
{
    Animator _playerAnimator;
    void Start()
    {
        _playerAnimator = EtraCharacterMainController.Instance.modelParent.GetComponentInChildren<Animator>();
    }
    public void MoveNear(float x)
    {
        _playerAnimator.transform.position = new Vector3(_playerAnimator.transform.position.x+x, _playerAnimator.transform.position.y, _playerAnimator.transform.position.z);
    }
}
