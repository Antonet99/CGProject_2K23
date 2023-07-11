using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkState : StateMachineBehaviour
{
    private Transform attackWayPoint,defendWayPoint;
    private NavMeshAgent agent;
    private float distanceAttack = 1.2f;
    private string[] attacks = new string[]{"Kick", "Punch"};

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        attackWayPoint=GameObject.FindGameObjectWithTag("AttackWayPoint").transform;
        defendWayPoint=GameObject.FindGameObjectWithTag("DefendWayPoint").transform;
        //playerTransform=GameObject.Find("EtraCharacterAssetBase").transform;
        agent.speed = 3.5f;
        //agent.SetDestination(attackWayPoint.position);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(attackWayPoint.position);
        float distance = Vector3.Distance(attackWayPoint.position,animator.transform.position);
        if (distance<=distanceAttack)
        {
            animator.transform.LookAt(attackWayPoint);
            //animator.SetBool("IsWalking",false);
            animator.SetTrigger(attacks[Random.Range(0,attacks.Length)]);
        }
        if(agent.remainingDistance==agent.stoppingDistance)
        {
        agent.SetDestination(agent.transform.position);    
        }
        if(agent.remainingDistance<agent.stoppingDistance)
        {
            agent.speed = 4.8f;
            agent.SetDestination(defendWayPoint.position);
            //animator.SetBool("IsWalking",true);
        }
        agent.speed = 3.5f;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);    
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
