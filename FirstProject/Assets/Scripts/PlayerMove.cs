using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMove : MonoBehaviour
{

    
    [SerializeField] float jumpForce = 10f;
    [SerializeField] float gravity = 10f;
    float StaminaValue = 100;

    [SerializeField] GameObject GameOver;
    [SerializeField] CharacterController controller;
    [SerializeField] float speed = 5f;
    [SerializeField] Slider stamina;
    bool knifeAct;


    
    private Vector3 direction;
    void Start()
    {
        
        stamina = GameObject.Find("SliderStamina").GetComponent<Slider>();
    }    
    void Update()
    {
        stamina.value = StaminaValue;
        knifeAct = GameObject.FindGameObjectWithTag("Player").GetComponent<Switch>().getknifeAct();

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
    
    
    private void isRunning(){
        
        updateStamina(-0.1f);
        setSpeed(18);
    }
    private void stopRunning()
    {
        if (knifeAct == false){
            setSpeed(5);
        }
        else setSpeed(15);
        
    }
    public void updateStamina(float curStamina){
        if (StaminaValue <= 0){
            stopRunning();
        }
        
        StaminaValue += curStamina;
    }
    public void setSpeed(float uspeed){
        speed = uspeed;
    }
    
    
}