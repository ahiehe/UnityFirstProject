using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Goblin : Enemy
{
    
    void start(){
        health = 120;
        damage = 10;
    }
    float timer = 0;
    float timerForAnim = 0;
    float cooldown = 1f;
    float cooldownForAnim = 0.12f;
   
    bool PlayerNear;
    bool pause;


    public override void Move()
    {
        pause = player.GetComponent<PlayerController>().GetPause();
        if (pause == false) 
        {
            GetComponent<Animator>().SetBool("PlayerNear", true);
            transform.LookAt(player.transform);
            GetComponent<CharacterController>().Move(3 * transform.forward * Time.deltaTime * 2);
        }
        else 
        {
            GetComponent<Animator>().SetBool("PlayerNear", false);
        }
    }

    public override void Attack()
    {
        
        if (Vector3.Distance(transform.position, player.transform.position) < 6) 
        {   
            timer += Time.deltaTime;
            if (timer > cooldown)
            {
                timerForAnim += Time.deltaTime;
                GetComponent<Animator>().SetBool("AttackPlayer", true);
                

                if (timerForAnim > cooldownForAnim)
                {
                    timerForAnim = 0;
                    timer = 0;
                    player.GetComponent<PlayerController>().ChangeHealth(-damage);
                }
                    
                
            }
        }
        
    }

    


}

