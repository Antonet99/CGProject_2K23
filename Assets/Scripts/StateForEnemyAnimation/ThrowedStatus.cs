using Etra.StarterAssets.Abilities;
using UnityEngine;
using Etra.StarterAssets;
public class ThrowedStatus : StateMachineBehaviour
{
    Transform player;
    Transform enemy;
    public float xangle, yangle, zangle, xoffset, yoffset, zoffset;
    private ABILITY_CharacterMovement _characterMovement;
        //private Vector3 currentEnemyRotation;
        //private Quaternion newRotation, newEnemyRotation;
        
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.Find("EtraCharacterAssetBase").GetComponent<Transform>();
        //enemy = animator.GetComponentInParent<Transform>();
        _characterMovement = EtraCharacterMainController.Instance.etraAbilityManager.GetComponent<ABILITY_CharacterMovement>();
        //currentEnemyRotation = animator.transform.rotation.eulerAngles;
        //newEnemyRotation=Quaternion.Euler(currentEnemyRotation.x,currentEnemyRotation.y,90);
        //animator.transform.rotation = newEnemyRotation;
        animator.transform.rotation = Quaternion.Euler(xangle,yangle,zangle);
        //animator.transform.position = new Vector3(player.position.x+xoffset, player.position.y+yoffset, player.position.z+zoffset);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _characterMovement.enabled = true;
        _characterMovement.distanceAmong=1;    
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
        // Implement code that sets up animation IK (inverse kinematics)
        //animator.bodyPosition = new Vector3(player.position.x+xoffset, player.position.y+yoffset, player.position.z);
        //animator.bodyRotation = Quaternion.Euler(0,yangle,0);
    //}
}
