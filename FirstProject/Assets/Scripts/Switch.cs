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
    [SerializeField] Text AmmoText;
    bool knifeAct = false;




    public enum Weapon { Pistol, Shotgun, Rifle, Knife}
    public Weapon weapon;
    void Start()
    {
        ChooseWeapon(Weapon.Pistol);
        AmmoUpdate();
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
            AmmoText.text =" ";
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
                    AmmoUpdate();
                    break;
                case Weapon.Shotgun:
                    shotgun.GetComponent<Gun>().Reloading();
                    AmmoUpdate();
                    break;
                case Weapon.Rifle:
                    rifle.GetComponent<Gun>().Reloading();
                    AmmoUpdate();
                    break;
                
                

            }    
                
        }
    }   

    public void AmmoUpdate(){
        AmmoText.color = Color.black;
        switch (weapon)
            {
            case Weapon.Pistol:
                AmmoText.text = pistol.GetComponent<Gun>().AmmoCurrent + "/" + pistol.GetComponent<Gun>().AmmoEvery;
                if ((pistol.GetComponent<Gun>().AmmoCurrent) <= 0) AmmoText.color = Color.red;
                break;
            case Weapon.Shotgun:
                AmmoText.text = shotgun.GetComponent<Gun>().AmmoCurrent + "/" + shotgun.GetComponent<Gun>().AmmoEvery;
                if ((shotgun.GetComponent<Gun>().AmmoCurrent) <= 0) AmmoText.color = Color.red;
                break;
            case Weapon.Rifle:
                AmmoText.text = rifle.GetComponent<Gun>().AmmoCurrent + "/" + rifle.GetComponent<Gun>().AmmoEvery;
                if ((rifle.GetComponent<Gun>().AmmoCurrent) <= 0) AmmoText.color = Color.red;
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
                    shotgun.GetComponent<Gun>().UppAmmo(16);
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

                break;
            case Weapon.Shotgun:
                pistol.SetActive(false);
                shotgun.SetActive(true);
                rifle.SetActive(false);
                knife.SetActive(false);

                break;
            case Weapon.Rifle:
                pistol.SetActive(false);
                shotgun.SetActive(false);
                rifle.SetActive(true);
                knife.SetActive(false);

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