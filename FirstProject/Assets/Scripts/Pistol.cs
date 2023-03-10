using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Gun
{
    void Start()
    {        
        cooldown = 0;        
        auto = false;
    }
    protected override void OnShoot()
    {
        GameObject buf = Instantiate(bullet);
        //buf.GetComponent<Bullet>().NoFriendlyFire();
        buf.GetComponent<Bullet>().setDirection(transform.forward);
        buf.transform.position = rifleStart.transform.position;
        float x = Random.Range(-30, 30);
        float y = Random.Range(-10, 10);
        buf.transform.rotation = transform.rotation;
        buf.GetComponent<Bullet>().setDirection(transform.forward + new Vector3(x / 500, y / 500, 0));
    }
}
