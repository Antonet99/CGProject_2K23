using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSelection : MonoBehaviour
{
    [SerializeField]
    public Animator animator;
    public bool isBlocking=false, isWinner=false;

    [ContextMenu("Punch!")]
    public void Punching()
    {
        animator.SetTrigger("Punching");
    }
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
    }
}
