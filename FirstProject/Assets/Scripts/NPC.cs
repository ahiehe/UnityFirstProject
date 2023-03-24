using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    [SerializeField] public GameObject player;
    [SerializeField] public GameObject playerRbuttonTip;
    [SerializeField] public GameObject ShopInterface;
    [SerializeField] public GameObject InGameUI;
    [SerializeField] public GameObject BuyButton;
    [SerializeField] public GameObject notEnoughCoins;
    protected bool isInShop = false;

    void Update()
    {
        if ((Vector3.Distance(transform.position, player.transform.position) < 10) && (Vector3.Distance(transform.position, player.transform.position) > 9)){
            GetComponent<Animator>().SetTrigger("IsPlayerNearby");
        }

        if (Vector3.Distance(transform.position, player.transform.position) < 5){
            playerRbuttonTip.SetActive(true);
        }
        else {
            playerRbuttonTip.SetActive(false);
            if (isInShop){
                CloseShop();
            }
            
        }

        if (playerRbuttonTip.activeSelf){
            if (Input.GetKeyDown(KeyCode.E)){
                if (isInShop == true){
                    CloseShop();
                }
                else {
                    OpenShop();
                    
                }
                
            }
            
        }
    }
    public virtual void OpenShop(){

    }
    public virtual void CloseShop(){

    }
}
