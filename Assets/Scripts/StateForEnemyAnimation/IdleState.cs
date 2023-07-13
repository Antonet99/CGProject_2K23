using UnityEngine;


public class IdleState : StateMachineBehaviour
{
    private Transform attackWayPoint;
    private float distanceRangeMax = 20f;
    private string[] attacks = new string[]{"Punch","Kick"};
    //private int[] attacksDamage = new int[]{2,3};
    private int randomNum;
    private HealthStatusManager _healthStatusManager;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        attackWayPoint=GameObject.FindGameObjectWithTag("AttackWayPoint").transform;
        _healthStatusManager=GameObject.Find("EtraCharacterAssetBase").GetComponent<HealthStatusManager>();
        randomNum = Random.Range(0, attacks.Length+2);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float distance = Mathf.Abs(attackWayPoint.position.x-animator.transform.position.x);
        if (distance>0.5 && distance<distanceRangeMax)
        {
            animator.SetBool("IsWalking",true);
        }
        else
        {
            if (randomNum==2)
            {
                _healthStatusManager.SetStatus("block",true,"enemy");
                animator.SetBool("Block",true);
            }
            else if (randomNum==3)
            {
                _healthStatusManager.SetStatus("blockDown",true,"enemy");
                animator.SetBool("DownBlock",true);
            }
            else
            {
                animator.transform.rotation=Quaternion.Euler(0f,269.445f,0f);
                animator.SetTrigger(attacks[randomNum]);
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //     
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //   
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //}
}
