using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pistol : Gun
{

    void Start()
    {        
        cooldown = 0;        
        auto = false;
        AmmoPerMagazin  = 10;
        ammoPerShoot = 1;
        if (PlayerPrefs.HasKey("pistolAmmo"))
        {
            AmmoEvery = PlayerPrefs.GetInt("pistolAmmo");
            AmmoCurrent= PlayerPrefs.GetInt("pistolAmmoC");
        } 
        else
        {
            AmmoEvery = 50;
            AmmoCurrent= 10;
        }
    }
    protected override void OnShoot()
    {
        GameObject buf = Instantiate(bullet);
        //buf.GetComponent<Bullet>().NoFriendlyFire();
        buf.GetComponent<Bullet>().setDirection(transform.forward);
        buf.GetComponent<Bullet>().NoFriendlyFire();
        buf.transform.position = rifleStart.transform.position;
        float x = Random.Range(-30, 30);
        float y = Random.Range(-10, 10);
        buf.transform.rotation = transform.rotation;
        buf.GetComponent<Bullet>().setDirection(transform.forward + new Vector3(x / 500, y / 500, 0));
    }
}
