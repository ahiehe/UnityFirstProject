using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    [SerializeField] protected Transform rifleStart;
    [SerializeField] protected GameObject bullet;
    

    protected bool auto = false;
    protected float cooldown = 0;

    public int ammo = 30;
    public int ammoMax = 30;

    public int ammoPerShoot = 1;

    private float timer = 0;

    public void Shoot()
    {
        if (Input.GetMouseButtonDown(0) || auto)
        {
            if (timer > cooldown)
            {
                if (ammo >= ammoPerShoot){
                    OnShoot();
                    ammo -= ammoPerShoot;
                    
                    timer = 0;
                } 
                
            }
        }
    }

    protected virtual void OnShoot()
    {

    }
    private void Start()
    {
        timer = cooldown;
    }
    private void Update()
    {
        timer += Time.deltaTime;
    }
}