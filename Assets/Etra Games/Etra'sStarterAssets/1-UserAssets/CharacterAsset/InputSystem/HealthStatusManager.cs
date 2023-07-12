using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthStatusManager : MonoBehaviour
{
    private float playerLife, enemyLife;
    private bool playerBlock, playerBlockDown, enemyBlock, enemyBlockDown;
    // Start is called before the first frame update
    void Start()
    {
        playerBlock = false;
        playerBlockDown = false;
        enemyBlock=false;
        enemyBlockDown = false;
        playerLife=100;
        enemyLife=100;  
    }

    public void takeDamage(float damage,string character,string attackType)
    {
        if(character=="player")
        {
            if(attackType=="punch" && playerBlock==true)
            {
                playerLife=playerLife-(damage/2);
            }
            else if(attackType=="kick" && playerBlockDown==true)
            {
                playerLife=playerLife-(damage/2);
            }
            else
            {
                playerLife=playerLife-damage;
            }
        }
        else if(character=="enemy")
        {
            enemyLife=enemyLife-damage;
        }
    }

    public float GetHealth(string character)
    {
        if(character=="player")
        {
            return playerLife;
        }
        else if(character=="enemy")
        {
            return enemyLife;
        }
        else
        {
            return 0;
        }
    }

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
    // Update is called once per frame
    //void Update()
    //{
        
    //}
}
