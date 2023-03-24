using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Riffle : Gun
{
    

    void Start()
    {        
        cooldown = 0;        
        auto = true;
        
        AmmoPerMagazin  = 30;
        ammoPerShoot = 1;
        if (PlayerPrefs.HasKey("rifleAmmo"))
        {
            AmmoEvery  = PlayerPrefs.GetInt("rifleAmmo") + 30;
            AmmoCurrent= PlayerPrefs.GetInt("rifleAmmoC");
        } 
        else
        {
            AmmoEvery  = 150;
            AmmoCurrent= 30;
        }
    }
    protected override void OnShoot()
    {
        GameObject buf = Instantiate(bullet);
        buf.GetComponent<Bullet>().setDirection(transform.forward);
        buf.GetComponent<Bullet>().NoFriendlyFire();
        buf.transform.position = rifleStart.transform.position;
        float x = Random.Range(-30, 30);
        float y = Random.Range(-10, 10);
        buf.transform.rotation = transform.rotation;
        buf.GetComponent<Bullet>().setDirection(transform.forward + new Vector3(x / 500, y / 500, 0));
    }
    public override void Reloading(){
        if (AmmoEvery >= (AmmoPerMagazin - AmmoCurrent)){
            AmmoEvery -= AmmoPerMagazin - AmmoCurrent;
            AmmoCurrent +=  AmmoPerMagazin - AmmoCurrent;
            //AmmoText.color = Color.black;
        }
        
    }
}
