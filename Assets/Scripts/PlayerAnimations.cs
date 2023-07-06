using Etra.StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    public bool isBlocking=false, isWinner=false;

    void Start()
    {
        _animator = EtraCharacterMainController.Instance.modelParent.GetComponentInChildren<Animator>();
    }
    public void OnPunch(InputValue value)
        {
            PunchInput(value.isPressed);
        }
    
    public void PunchInput(bool PunchState)
        {
            if(PunchState){
            _animator.SetTrigger("Punch");
            }
        }
    void Update(){
     if (Input.GetButtonDown("Punch"))
            {
                PunchInput(true);
            }
    }
    /*
    [ContextMenu("Kick!")]
    public void Kicking()
    {
        animator.SetTrigger("Kicking");
    }
    [ContextMenu("Block!")]
    public void Blocking()
    {
        isBlocking=!isBlocking;
        animator.SetBool("Blocking", isBlocking);
    }
    [ContextMenu("Winner!")]
    public void Winning()
    {
        isWinner=!isWinner;
        animator.SetBool("Winning", isWinner);
    }*/
}
