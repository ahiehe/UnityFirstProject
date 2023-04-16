using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class PlayerController : MonoBehaviour
{


    [SerializeField] Text HpText;
    [SerializeField] int health;
    int maxHealth = 100;
    public int coins = 0;
    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject pauseUI;
    [SerializeField] GameObject InGameUI;
    [SerializeField]Text coinsText;

    [SerializeField] GameObject pistol;
    [SerializeField] GameObject shotgun;
    [SerializeField] GameObject rifle;


    bool pause = false;


    


    public void ChangeHealth(int count)
    {   
        if ((health + count)  >= maxHealth){
            health += maxHealth - health;
        }
        else health = health + count;
        if (health <= 0) 
        {
            GetComponent<PlayerLook>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
            GetComponent<PlayerMove>().enabled = false;           
            InGameUI.SetActive(false);
            gameOver.SetActive(true);
        }
        
        HpText.text = "Здоровье: " + health.ToString();
    }

    public int GetHealth()
    {
      return health;
    }
   
    public void ChangeCoins(int count){
        coins += count;
        coinsText.text = "Монет: " + coins.ToString();
    }
    public int GetCoins(){
        return coins;
    }
    void Start()
    {
        ChangeCoins(coins);
        if (PlayerPrefs.HasKey("health"))
        {
            ChangeHealth(PlayerPrefs.GetInt("health"));
        } 
        else
        {
            ChangeHealth(100);
        }

        if (PlayerPrefs.HasKey("coins"))
        {
            ChangeCoins(PlayerPrefs.GetInt("coins"));
        } 
        else
        {
            ChangeCoins(0);
        }

    }

    

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pause == true)
            {
                pause = false;
                GetComponent<PlayerLook>().enabled = true;
                GetComponent<PlayerMove>().enabled = true;

                Cursor.lockState = CursorLockMode.Locked;
                pauseUI.SetActive(false);
                InGameUI.SetActive(true);

            }
            else
            {
                pause = true;
                GetComponent<PlayerLook>().enabled = false;
                GetComponent<PlayerMove>().enabled = false;

                Cursor.lockState = CursorLockMode.None;
                pauseUI.SetActive(true);
                InGameUI.SetActive(false);
            }
        }


        
    }


    public bool GetPause()
    {
      return pause;
    }



    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Heal")
        {
            Destroy(collider.gameObject);
            ChangeHealth(50);
        }
        if (collider.tag == "AddAmmo")
        {
            Destroy(collider.gameObject);
            if (pistol.activeSelf){
                pistol.GetComponent<Gun>().UppAmmo(10);

            }
            if (shotgun.activeSelf){
                shotgun.GetComponent<Gun>().UppAmmo(4);

            }
            if (rifle.activeSelf){
                rifle.GetComponent<Gun>().UppAmmo(30);
                
            }
            GetComponent<Switch>().AmmoUpdate();
        }
        if (collider.tag == "Water") 
        {
            GetComponent<PlayerLook>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
            GetComponent<PlayerMove>().enabled = false;           
            InGameUI.SetActive(false);
            gameOver.SetActive(true);
        }
    }
}
