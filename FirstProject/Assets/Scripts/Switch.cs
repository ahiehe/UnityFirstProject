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
    Weapon weapon;
    void Start()
    {
        ChooseWeapon(Weapon.Pistol);
        AmmoText.text = pistol.GetComponent<Gun>().ammo + "/" + pistol.GetComponent<Gun>().ammoMax;
    }
    void Update()
    {        
        if (Input.GetKey(KeyCode.Alpha1))
        {
            ChooseWeapon(Weapon.Pistol);
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>().setSpeed(5);
            AmmoText.text = pistol.GetComponent<Gun>().ammo + "/" + pistol.GetComponent<Gun>().ammoMax;
            knifeAct = false;
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            ChooseWeapon(Weapon.Shotgun);
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>().setSpeed(5);
            AmmoText.text = shotgun.GetComponent<Gun>().ammo + "/" + shotgun.GetComponent<Gun>().ammoMax;
            knifeAct = false;
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            ChooseWeapon(Weapon.Rifle);
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>().setSpeed(5);
            AmmoText.text = rifle.GetComponent<Gun>().ammo + "/" + rifle.GetComponent<Gun>().ammoMax;
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
                    AmmoText.text = pistol.GetComponent<Gun>().ammo + "/" + pistol.GetComponent<Gun>().ammoMax;
                    break;
                case Weapon.Shotgun:
                    shotgun.GetComponent<Gun>().Shoot();
                    AmmoText.text = shotgun.GetComponent<Gun>().ammo + "/" + shotgun.GetComponent<Gun>().ammoMax;
                    break;
                case Weapon.Rifle:
                    rifle.GetComponent<Gun>().Shoot();
                    AmmoText.text = rifle.GetComponent<Gun>().ammo + "/" + rifle.GetComponent<Gun>().ammoMax;
                    break;
                
                

            }
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