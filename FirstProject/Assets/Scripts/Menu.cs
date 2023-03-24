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
        SceneManager.LoadScene(1); //указываем номер сцены для загрузки
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



