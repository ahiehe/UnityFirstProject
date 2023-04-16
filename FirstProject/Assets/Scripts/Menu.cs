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

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void RetryGame()
    {
        Promejutok.wave = 1;
        PlayerPrefs.SetInt("health", 100);
        PlayerPrefs.SetInt("coins", 0);

        PlayerPrefs.SetInt("pistolAmmo",30);
        PlayerPrefs.SetInt("shotgunAmmo", 12);
        PlayerPrefs.SetInt("rifleAmmo", 90);

        PlayerPrefs.SetInt("pistolAmmoC",10);
        PlayerPrefs.SetInt("shotgunAmmoC", 4);
        PlayerPrefs.SetInt("rifleAmmoC", 30);
        PlayerPrefs.Save();
        SceneManager.LoadScene(0); 
    }
    public void SaveAmmoAndHP()
    {
        int health = player.GetComponent<PlayerController>().GetHealth();
        int coins = player.GetComponent<PlayerController>().GetCoins();

        int pistolAmmoEvery = pistol.GetComponent<Gun>().AmmoEvery;
        int shotgunAmmoEvery = shotgun.GetComponent<Gun>().AmmoEvery;
        int rifleAmmoEvery = rifle.GetComponent<Gun>().AmmoEvery;

        int pistolAmmoCurrent = pistol.GetComponent<Gun>().AmmoCurrent;
        int shotgunAmmoCurrent = shotgun.GetComponent<Gun>().AmmoCurrent;
        int rifleAmmoCurrent = rifle.GetComponent<Gun>().AmmoCurrent;
        int wave = Promejutok.wave;
        
        if (health > 0)
        {
            PlayerPrefs.SetInt("health", health);
            PlayerPrefs.SetInt("coins", coins);

            PlayerPrefs.SetInt("pistolAmmo",pistolAmmoEvery);
            PlayerPrefs.SetInt("shotgunAmmo", shotgunAmmoEvery);
            PlayerPrefs.SetInt("rifleAmmo", rifleAmmoEvery);

            PlayerPrefs.SetInt("pistolAmmoC",pistolAmmoCurrent);
            PlayerPrefs.SetInt("shotgunAmmoC", shotgunAmmoCurrent);
            PlayerPrefs.SetInt("rifleAmmoC", rifleAmmoCurrent);

            PlayerPrefs.SetInt("wave", wave);
            PlayerPrefs.Save();
        }
    }

    
}



