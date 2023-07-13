using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthStatusManager : MonoBehaviour
{
    private bool playerBlock, playerBlockDown, enemyBlock, enemyBlockDown;
    private Animator playerAnimator, enemyAnimator;
    public Image playerBar, enemyBar;
    //+[HideInInspector]
    public float playerLife, enemyLife;
    [HideInInspector]
    public RectTransform playerBarTransform, enemyBarTransform;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator=GameObject.Find("DefaultArmatureCharacterModel").GetComponent<Animator>();
        enemyAnimator=GameObject.Find("Enemy").GetComponent<Animator>();
        playerBlock = false;
        playerBlockDown = false;
        enemyBlock=false;
        enemyBlockDown = false;
        playerLife=100;
        enemyLife=100;
        playerBarTransform=playerBar.GetComponent<RectTransform>();
        enemyBarTransform=enemyBar.GetComponent<RectTransform>();  
    }

    public void takeDamage(float damage,string character,string attackType)
    {
        if(character=="player")
        {
            bool defendedFromPunch = (attackType=="punch" && playerBlock==true);
            bool defendedFromKick = (attackType=="kick" && playerBlockDown==true);
            bool isAlive = playerLife > 0;
            EndGame(isAlive,enemyAnimator,playerAnimator);
            if(defendedFromPunch||defendedFromKick)
            {
                damage=damage/2;
            }
            playerLife=playerLife-damage;
            //playerBarTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal,playerBarTransform.rect.width-(damage*1.8f));
            //ResizeBar(playerLife, playerBarTransform);
        }
        else if(character=="enemy")
        {
            bool defendedFromPunch = (attackType=="punch" && enemyBlock==true);
            bool defendedFromKick = (attackType=="kick" && enemyBlockDown==true);
            bool isAlive = enemyLife > 0;
            EndGame(isAlive,playerAnimator,enemyAnimator);
            if(defendedFromPunch||defendedFromKick)
            {
                damage = damage/2;
            }
            enemyLife=enemyLife-damage;
            //enemyBarTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal,enemyBarTransform.rect.width-(damage*1.8f));
            //ResizeBar(enemyLife,enemyBarTransform);
        }
    }

    /*public float GetHealth(string character)
    {
        if(character=="player")
        {
            ResizeBar(playerLife,playerBarTransform);
            return playerLife;
        }
        else if(character=="enemy")
        {
            ResizeBar(enemyLife,enemyBarTransform);
            return enemyLife;
        }
        else
        {
            return 0;
        }
    }*/

    public void SetStatus(string type, bool status,string character)
    {
        if(character=="player" && type=="block")
        {
            playerBlock=status;
        }
        else if(character=="player" && type=="blockDown")
        {
            playerBlockDown=status;
        }
        else if(character=="enemy" && type=="block")
        {
            enemyBlock=status;
        }
        else if(character=="enemy" && type=="blockDown")
        {
            enemyBlockDown=status;
        }
    }

    public bool GetStatus(string type, string character)
    {
        if(character=="player" && type=="block")
        {
            return playerBlock;
        }
        else if(character=="player" && type=="blockDown")
        {
            return playerBlockDown;
        }
        else if(character=="enemy" && type=="block")
        {
            return enemyBlock;
        }
        else if(character=="enemy" && type=="blockDown")
        {
            return enemyBlockDown;
        }
        else
        {
            return false;
        }
    }

    public void EndGame(bool isAlive, Animator opponentAnimator, Animator animator)
    {
        if(!isAlive)
            {
                opponentAnimator.Play("Winning");
                animator.Play("Dying");
            }
    }

    public void ResizeBar(float life, RectTransform barTransform){
        float newWidth = 1.8f*life;
        barTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal,newWidth);
    }
}
