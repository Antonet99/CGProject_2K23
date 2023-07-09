using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthStatusManager : MonoBehaviour
{
    private float playerLife, enemyLife;
    private bool playerAttack, playerBlock, enemyAttack, enemyBlock;
    // Start is called before the first frame update
    void Start()
    {
        playerAttack = false;
        playerBlock = false;
        enemyAttack=false;
        enemyBlock = false;
        playerLife=100;
        enemyLife=100;  
    }

    public void takeDamage(float damage,string character)
    {
        if(character=="player")
        {
            playerLife=playerLife-damage;
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
        if(character=="player" && type=="attack")
        {
            playerAttack=status;
        }
        else if(character=="player" && type=="block")
        {
            playerBlock=status;
        }
        else if(character=="enemy" && type=="attack")
        {
            enemyAttack=status;
        }
        else if(character=="enemy" && type=="block")
        {
            enemyBlock=status;
        }
    }

    public bool GetStatus(string type, string character)
    {
        if(character=="player" && type=="attack")
        {
            return playerAttack;
        }
        else if(character=="player" && type=="block")
        {
            return playerBlock;
        }
        else if(character=="enemy" && type=="attack")
        {
            return enemyAttack;
        }
        else if(character=="enemy" && type=="block")
        {
            return enemyBlock;
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
