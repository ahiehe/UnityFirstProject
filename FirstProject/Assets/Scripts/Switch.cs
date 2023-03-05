using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Switch : MonoBehaviour
{
    [SerializeField] GameObject pistol;
    [SerializeField] GameObject shotgun;
    [SerializeField] GameObject rifle;



    public enum Weapon { Pistol, Shotgun, Rifle}
    Weapon weapon;
    void Start()
    {
        
    }
    void Update()
    {        
        if (Input.GetKey(KeyCode.Alpha1))
        {
            ChooseWeapon(Weapon.Pistol);
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            ChooseWeapon(Weapon.Shotgun);
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            ChooseWeapon(Weapon.Rifle);
        }      
           
       
        if (Input.GetMouseButton(0))
        {
            switch (weapon)
            {
                case Weapon.Pistol:
                    pistol.GetComponent<Gun>().Shoot();
                    break;
                case Weapon.Shotgun:
                    shotgun.GetComponent<Gun>().Shoot();
                    break;
                case Weapon.Rifle:
                    rifle.GetComponent<Gun>().Shoot();
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

                break;
            case Weapon.Shotgun:
                pistol.SetActive(false);
                shotgun.SetActive(true);
                rifle.SetActive(false);

                break;
            case Weapon.Rifle:
                pistol.SetActive(false);
                shotgun.SetActive(false);
                rifle.SetActive(true);

                break;
            default:
                print("Такого оружия у вас нет");
                break;
        }
    }
}