using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    [SerializeField] protected Transform rifleStart;
    [SerializeField] protected GameObject bullet;
    //[SerializeField] protected Text AmmoText;

    protected bool auto = false;
    protected float cooldown = 0;

    public int AmmoCurrent= 10;
    public int AmmoPerMagazin  = 10;
    public int AmmoEvery = 50;

    public int ammoPerShoot = 1;

    private float timer = 0;

    public void Shoot()
    {
        if (Input.GetMouseButtonDown(0) || auto)
        {
            if (timer > cooldown)
            {
                if (AmmoCurrent > 0){
                    OnShoot();
                    GetComponent<AudioSource>().Play();
                    AmmoCurrent -= ammoPerShoot;
                    
                    timer = 0;
                } 
                
            }
        }
    }
    public void Reloading()
    {
        if (AmmoCurrent == AmmoPerMagazin) return; //Ничего не делать если полная обойма
        if (AmmoEvery == 0) return; //Ничего не делать если нет ничего в запасе
        Invoke("InvokeReloading", 1);
    }
    public void InvokeReloading(){
        if (AmmoEvery >= (AmmoPerMagazin - AmmoCurrent)){
            AmmoEvery -= AmmoPerMagazin - AmmoCurrent;
            AmmoCurrent +=  AmmoPerMagazin - AmmoCurrent;
            
        }
        else {
            AmmoCurrent += AmmoEvery;
            AmmoEvery = 0;
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
    public void UppAmmo(int addiction){
        AmmoEvery += addiction;
    }
}