using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickState : StateMachineBehaviour
{
    private HealthStatusManager _healthStatusManager;
    Transform enemy, player;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _healthStatusManager=GameObject.Find("EtraCharacterAssetBase").GetComponent<HealthStatusManager>();
        _healthStatusManager.takeDamage(3,"player","kick");    
        _healthStatusManager.ResizeBar(_healthStatusManager.playerLife,_healthStatusManager.playerBarTransform);
        player = GameObject.Find("EtraCharacterAssetBase").GetComponent<Transform>();
        enemy = animator.GetComponentInParent<Transform>();
        enemy.transform.position = new Vector3(player.position.x+2, player.position.y, player.position.z);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
        // Implement code that sets up animation IK (inverse kinematics)
        //animator.bodyPosition = new Vector3(animator.transform.position.x+5, animator.transform.position.y, animator.transform.position.z);
    //}
}
