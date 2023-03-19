using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject pistol;
    [SerializeField] GameObject shotgun;
    [SerializeField] GameObject rifle;

    public void SaveAmmoAndHP()
    {
        int health = player.GetComponent<PlayerController>().GetHealth();
        int pistolAmmo = pistol.GetComponent<Gun>().ammo;
        int shotgunAmmo = shotgun.GetComponent<Gun>().ammo;
        int rifleAmmo = rifle.GetComponent<Gun>().ammo;
        int wave = Promejutok.wave;
        
        if (health > 0)
        {
            PlayerPrefs.SetInt("health", health);
            PlayerPrefs.SetInt("pistolAmmo",pistolAmmo);
            PlayerPrefs.SetInt("shotgunAmmo", shotgunAmmo);
            PlayerPrefs.SetInt("rifleAmmo", rifleAmmo);
            PlayerPrefs.SetInt("wave", wave);
            PlayerPrefs.Save();
        }
    }

    
}



