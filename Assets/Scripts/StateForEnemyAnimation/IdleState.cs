using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : StateMachineBehaviour
{
    //private GameObject player;
    //private Transform playerTransform;
    private Transform attackWayPoint;
    private float distanceRangeMin = 2f;
    private float distanceRangeMax = 8f;
    private float distanceAttack = 1.2f;
    private string[] attacks = new string[]{"Kick", "Punch"};

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        attackWayPoint=GameObject.FindGameObjectWithTag("AttackWayPoint").transform;
        //player=GameObject.Find("EtraCharacterAssetBase");
        //playerTransform=player.transform;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float distance = Vector3.Distance(attackWayPoint.position,animator.transform.position);
        if (distance>distanceRangeMin && distance<distanceRangeMax)
        {
            animator.SetBool("IsWalking",true);
        }
        if (distance<=distanceAttack)
        {
            animator.transform.LookAt(attackWayPoint);
            animator.SetTrigger(attacks[Random.Range(0,attacks.Length)]);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    // OnStateIK is called right after Animator.OnAnimatorIK()
    override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }
}
