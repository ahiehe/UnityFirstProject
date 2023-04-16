using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Switch : MonoBehaviour
{
    [SerializeField] GameObject pistol;
    [SerializeField] GameObject shotgun;
    [SerializeField] GameObject rifle;
    [SerializeField] GameObject knife;
    [SerializeField] GameObject pistolUI;
    [SerializeField] GameObject shotgunUI;
    [SerializeField] GameObject rifleUI;
    [SerializeField] Text PistolAmmoText;
    [SerializeField] Text ShotgunAmmoText;
    [SerializeField] Text RifleAmmoText;
    bool knifeAct = false;




    public enum Weapon { Pistol, Shotgun, Rifle, Knife}
    public Weapon weapon;
    void Start()
    {
        ChooseWeapon(Weapon.Pistol);
        AmmoUpdate();

        ShotgunAmmoText.text = shotgun.GetComponent<Gun>().AmmoCurrent + "/" + shotgun.GetComponent<Gun>().AmmoEvery;
        if ((shotgun.GetComponent<Gun>().AmmoCurrent) <= 0) ShotgunAmmoText.color = Color.red;
        else ShotgunAmmoText.color = Color.black;

        RifleAmmoText.text = rifle.GetComponent<Gun>().AmmoCurrent + "/" + rifle.GetComponent<Gun>().AmmoEvery;
        if ((rifle.GetComponent<Gun>().AmmoCurrent) <= 0) RifleAmmoText.color = Color.red;
        else RifleAmmoText.color = Color.black;

    }
    void Update()
    {        
        if (Input.GetKey(KeyCode.Alpha1))
        {
            ChooseWeapon(Weapon.Pistol);
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>().setSpeed(5);
            AmmoUpdate();
            knifeAct = false;
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            ChooseWeapon(Weapon.Shotgun);
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>().setSpeed(5);
            AmmoUpdate();
            knifeAct = false;
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            ChooseWeapon(Weapon.Rifle);
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>().setSpeed(5);
            AmmoUpdate();
            knifeAct = false;
        }    
        if (Input.GetKey(KeyCode.Alpha4))
        {
            ChooseWeapon(Weapon.Knife);
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>().setSpeed(15);
            knifeAct = true;
        }   
           
       
        if (Input.GetMouseButton(0))
        {
            switch (weapon)
            {
                case Weapon.Pistol:
                    pistol.GetComponent<Gun>().Shoot();
                    AmmoUpdate();
                    break;
                case Weapon.Shotgun:
                    shotgun.GetComponent<Gun>().Shoot();
                    AmmoUpdate();
                    break;
                case Weapon.Rifle:
                    rifle.GetComponent<Gun>().Shoot();
                    AmmoUpdate();
                    break;
                
                

            }
        }
        if (Input.GetKeyDown(KeyCode.R)){
            switch (weapon)
            {
                case Weapon.Pistol:
                    pistol.GetComponent<Gun>().Reloading();
                    
                    break;
                case Weapon.Shotgun:
                    shotgun.GetComponent<Gun>().Reloading();
                    
                    break;
                case Weapon.Rifle:
                    rifle.GetComponent<Gun>().Reloading();
                    
                    break;
                
                

            }  
            Invoke("AmmoUpdate",1);  
                
        }
    }   

    public void AmmoUpdate(){
        switch (weapon)
            {
            case Weapon.Pistol:
                PistolAmmoText.text = pistol.GetComponent<Gun>().AmmoCurrent + "/" + pistol.GetComponent<Gun>().AmmoEvery;
                if ((pistol.GetComponent<Gun>().AmmoCurrent) <= 0) PistolAmmoText.color = Color.red;
                else PistolAmmoText.color = Color.black;
                break;
            case Weapon.Shotgun:
                ShotgunAmmoText.text = shotgun.GetComponent<Gun>().AmmoCurrent + "/" + shotgun.GetComponent<Gun>().AmmoEvery;
                if ((shotgun.GetComponent<Gun>().AmmoCurrent) <= 0) ShotgunAmmoText.color = Color.red;
                else ShotgunAmmoText.color = Color.black;
                break;
            case Weapon.Rifle:
                RifleAmmoText.text = rifle.GetComponent<Gun>().AmmoCurrent + "/" + rifle.GetComponent<Gun>().AmmoEvery;
                if ((rifle.GetComponent<Gun>().AmmoCurrent) <= 0) RifleAmmoText.color = Color.red;
                else RifleAmmoText.color = Color.black;
                break;

            }

    }

    public void BuyAmmo(){
        switch (weapon)
            {
                case Weapon.Pistol:
                    pistol.GetComponent<Gun>().UppAmmo(10);
                    AmmoUpdate();
                    break;
                case Weapon.Shotgun:
                    shotgun.GetComponent<Gun>().UppAmmo(2);
                    AmmoUpdate();
                    break;
                case Weapon.Rifle:
                    rifle.GetComponent<Gun>().UppAmmo(30);
                    AmmoUpdate();
                    break;
                
                

            }
    }
    
    public void ChooseWeapon(Weapon weapon)
    {
        this.weapon = weapon;
        switch (weapon)
        {
            case Weapon.Pistol:
                pistol.SetActive(true);
                shotgun.SetActive(false);
                rifle.SetActive(false);
                knife.SetActive(false);
                pistolUI.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                shotgunUI.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
                rifleUI.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);

                break;
            case Weapon.Shotgun:
                pistol.SetActive(false);
                shotgun.SetActive(true);
                rifle.SetActive(false);
                knife.SetActive(false);
                pistolUI.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
                shotgunUI.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                rifleUI.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);

                break;
            case Weapon.Rifle:
                pistol.SetActive(false);
                shotgun.SetActive(false);
                rifle.SetActive(true);
                knife.SetActive(false);
                pistolUI.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
                shotgunUI.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
                rifleUI.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

                break;
            case Weapon.Knife:
                pistol.SetActive(false);
                shotgun.SetActive(false);
                rifle.SetActive(false);
                knife.SetActive(true);

                break;
            default:
                print("Такого оружия у вас нет");
                break;
        }
    }
    public bool getknifeAct (){
        return knifeAct;
    }
}