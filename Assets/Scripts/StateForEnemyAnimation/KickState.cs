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
        _healthStatusManager.takeDamage(5,"player","kick");    
        _healthStatusManager.ResizeBar(_healthStatusManager.playerLife,_healthStatusManager.playerBarTransform);
        player = GameObject.Find("EtraCharacterAssetBase").GetComponent<Transform>();
        enemy = animator.GetComponentInParent<Transform>();
        //enemy.transform.position = new Vector3(player.position.x+2.5f, player.position.y, player.position.z);
    }
}
