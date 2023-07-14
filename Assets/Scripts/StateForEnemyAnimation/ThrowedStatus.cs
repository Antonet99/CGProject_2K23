using Etra.StarterAssets.Abilities;
using UnityEngine;
using Etra.StarterAssets;
public class ThrowedStatus : StateMachineBehaviour
{
    Transform player;
    Transform enemy;
    public float xangle, yangle, zangle, xoffset, yoffset, zoffset;
    private ABILITY_CharacterMovement _characterMovement;
        
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.Find("EtraCharacterAssetBase").GetComponent<Transform>();
        _characterMovement = EtraCharacterMainController.Instance.etraAbilityManager.GetComponent<ABILITY_CharacterMovement>();
        animator.transform.rotation = Quaternion.Euler(xangle,yangle,zangle);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _characterMovement.enabled = true;
        _characterMovement.distanceAmong=1;    
    }
}
