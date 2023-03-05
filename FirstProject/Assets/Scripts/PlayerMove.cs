using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMove : MonoBehaviour
{

    
    [SerializeField] float jumpForce = 10f;
    [SerializeField] float gravity = 10f;
    float StaminaValue = 100;
    bool Running = false;
    [SerializeField] GameObject GameOver;
    [SerializeField] CharacterController controller;
    [SerializeField] float speed = 100f;
    [SerializeField] Slider stamina;



    
    private Vector3 direction;
    void Start()
    {
        
        stamina = GameObject.Find("SliderStamina").GetComponent<Slider>();
    }    
    void Update()
    {
        stamina.value = StaminaValue;

        if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                stopRunning();
            
            
            
            }

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        

         if (StaminaValue < 100)
            updateStamina(0.01f);  


        if (Input.GetKey(KeyCode.Q)) 
        {
            direction.y -= (gravity + 7) * Time.deltaTime;
        }

        if (controller.isGrounded)
        {
            direction = new Vector3(moveHorizontal, 0, moveVertical);
            direction = transform.TransformDirection(direction) * speed;
            if (Input.GetKey(KeyCode.Space)) 
            {
                direction.y = jumpForce;
                
            }

            if (Input.GetKey(KeyCode.X)) 
            {
                direction.y = jumpForce*12;

            }

            

            if (Input.GetKey(KeyCode.LeftShift))
            {
                if (StaminaValue >= 0)
                isRunning();
            
            
            
            }
            
                 
            
        }
        

        direction.y -= gravity * Time.deltaTime;
        controller.Move(direction * Time.deltaTime);
    }
    
    private void OnTriggerEnter(Collider other)
    {        
        

        if (other.tag == "Water") 
        {
            GameOver.SetActive(true);  
            GetComponent<PlayerLook>().enabled = false;
            Cursor.lockState = CursorLockMode.None;     
        }

    }
    
    private void isRunning(){
        Running = true;
        updateStamina(-0.1f);
        speed = 18f;
    }
    private void stopRunning()
    {
        Running = false;
        speed = 5f;
    }
    public void updateStamina(float curStamina){
        if (StaminaValue <= 0){
            stopRunning();
        }
        
        StaminaValue += curStamina;
    }
    
    
}