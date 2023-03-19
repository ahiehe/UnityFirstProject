using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Promejutok : MonoBehaviour
{
    public static int wave = 0;
    [SerializeField] GameObject Cam;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Cam.GetComponent<Menu>().SaveAmmoAndHP();
            LoadWave();
        }

    }

    public void LoadWave(){
        SceneManager.LoadScene(wave+1);
    
    }
}
