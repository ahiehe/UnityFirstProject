using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCAmmo : NPC
{
    public override void OpenShop(){
        isInShop = true;
        InGameUI.SetActive(false);
        ShopInterface.SetActive(true);
        if(player.GetComponent<PlayerController>().GetCoins() < 100){
            BuyButton.SetActive(false);
            notEnoughCoins.SetActive(true);
        }


        player.GetComponent<PlayerLook>().enabled = false;
        player.GetComponent<Switch>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
    }
    public override void CloseShop(){
        isInShop = false;
        InGameUI.SetActive(true);
        ShopInterface.SetActive(false);
        player.GetComponent<PlayerLook>().enabled = true;
        player.GetComponent<Switch>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        
    }
}
