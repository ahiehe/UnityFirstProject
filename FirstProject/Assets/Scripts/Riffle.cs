using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Riffle : Gun
{
    

    void Start()
    {        
        cooldown = 0;        
        auto = true;
        ammoMax = 90;
        ammoPerShoot = 1;
        if (PlayerPrefs.HasKey("rifleAmmo"))
        {
            ammo = PlayerPrefs.GetInt("rifleAmmo");
        } 
        else
        {
            ammo = 90;
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
}
