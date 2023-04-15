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
    
    protected float timer = 0;
    protected float timerForAnim = 0;
    protected float cooldown = 1f;
    protected float cooldownForAnim = 0.12f;
   
    bool PlayerNear;




    public override void Move()
    {

            GetComponent<Animator>().SetBool("PlayerNear", false);
            transform.LookAt(player.transform);
            GetComponent<CharacterController>().Move(6 * transform.forward * Time.deltaTime);
 
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
                    player.GetComponent<PlayerController>().ChangeHealth(-this.damage);
                }
                    
                
            }
        }
        
    }

    


}

