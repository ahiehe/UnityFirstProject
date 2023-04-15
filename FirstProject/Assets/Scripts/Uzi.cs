using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Uzi : Enemy
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform rifleStart;
    
    enum Firing { Wait, Prepare, Shoot }
    Firing fire = Firing.Wait;
    

    bool PlayerNear;

    float timer = 0;
    float cooldown = 0.5f;
    void start(){
        health = 200;

    }
    
    int area = 20;

    public override void Move()
    {
        
    }

    public override void Attack()
    {

        
        switch (fire)
        {
        case Firing.Wait:
                GetComponent<Animator>().SetBool("PlayerNear", false);
                transform.LookAt(player.transform);
                GetComponent<CharacterController>().Move(2 * transform.forward * Time.deltaTime * 2);
                if (Vector3.Distance(transform.position, player.transform.position) < area)
                {
                    GetComponent<Animator>().SetBool("PlayerNear", true);
                    timer = 0;
                    fire = Firing.Prepare;
                }
            

            
            break;
        case Firing.Prepare:
            transform.LookAt(player.transform);
            timer += Time.deltaTime;  
            if (timer > cooldown)
            {
                fire = Firing.Shoot;
            }
            if (Vector3.Distance(transform.position, player.transform.position) > area)
            {
                timer = 0;
                fire = Firing.Wait;
            }
            break;
        case Firing.Shoot:
            timer = 0;
            GetComponent<Animator>().SetBool("IsShoot", true);
            GameObject buf = Instantiate(bullet); 

            buf.transform.position = rifleStart.transform.position;
            buf.transform.rotation = transform.rotation;
            buf.GetComponent<Bullet>().setDirection(transform.forward);
            buf.GetComponent<Bullet>().MakeUzi();
            fire = Firing.Wait;
            break;
        }
        
    }
}
