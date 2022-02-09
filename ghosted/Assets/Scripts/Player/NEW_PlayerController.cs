using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//To reload the scene.
using UnityEngine.SceneManagement;

public class NEW_PlayerController : MonoBehaviour
{
    //The player
    public Rigidbody theRB;
    public float moveSpeed, jumpForce;
    private Vector2 moveInput;
    public Vector3 jump;
    public LayerMask whatIsGround;
    public Transform groundPoint;
    private bool isGrounded;
    public Animator animator;
    public SpriteRenderer theSR;
    
    public GameObject eKey;
    private bool movingBackwards;
    public Animator flipAnim;
    public float rotationSpeed;
    public Transform relativeTransform;
    public Inventory inventory;
    public int maxHealth = 50;
    public int startEctoplasm= 0;
    public int currentHealth;
    public int currentEctoplasm;
    public HealthBarScript healthBar;
    public EctoplasmBarScript ectoplasmBar;

   

    private bool touchingChest;
    private bool touchingDoor;

    public GameObject magicPrefab;

    public Camera playerCamera;

    public int playerHealth;
    public bool playerDeath;

    //Win and Loss Screen Popup handler variables
    public GameObject lossScreenUI;
    public GameObject winScreenUI;


    //Jump set
    void Start()
    {
        theRB = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, jumpForce, 0.0f);
        currentHealth = maxHealth;
        currentEctoplasm = startEctoplasm;
        healthBar.SetMaxHealth(maxHealth);
        ectoplasmBar.SetEctoplasm(startEctoplasm);
    }

    //Jump Collision Start
    void OnCollisionStay(){
        isGrounded = true;
    }
    //Jump Collision Exit
    void OnCollisionExit()
    {
            isGrounded = false;
    }


       private void OnCollisionEnter(Collision hit) {
             IInventoryItem item = hit.collider.GetComponent<IInventoryItem>();
        if(item != null)
        {
            Debug.Log("ITEM HIT");
            inventory.AddItem(item);
        }
       }

    // Update is called once per frame

    void Movement()
    {
        Vector3 moveDirection = Vector3.zero;
        Cursor.visible = true;
     
        if(Input.GetKeyDown(KeyCode.L))
        {
            TakeDamage(10);
        }
        if(currentEctoplasm <= 1000)
        {
            int runningTotal = startEctoplasm + EctoplasmAddSystem.theNumber;
            AddEctoplasm(runningTotal);
          
        }else{
            
            Debug.Log("Cannot collect anymore ectoplasm!");
        }
    
        

  
    

    //Direction Handler
        if(Input.GetKey(KeyCode.W)){  
            moveDirection += relativeTransform.forward; 
        }
        else if(Input.GetKey(KeyCode.S)) 
        {
            moveDirection += -relativeTransform.forward; 
           
        }
        if(Input.GetKey(KeyCode.A)) 
        {
            moveDirection += -relativeTransform.right;
           

        }
        else if(Input.GetKey(KeyCode.D)) {
            moveDirection += relativeTransform.right;
           
        }
    //Animation Handler
        if(!movingBackwards && Input.GetKeyDown(KeyCode.W)){  
            movingBackwards = true;
            flipAnim.SetTrigger("Flip");
        }
        else if(movingBackwards && Input.GetKeyDown(KeyCode.S)) {
            movingBackwards = false;
            flipAnim.SetTrigger("Flip"); 
        }
        if(!theSR.flipX && Input.GetKeyDown(KeyCode.A)) {
            theSR.flipX = true;
            flipAnim.SetTrigger("Flip");
        }
        else if(theSR.flipX && Input.GetKeyDown(KeyCode.D)) {
            theSR.flipX = false;
            flipAnim.SetTrigger("Flip");   
        }
    //Adding force to the rigid body to jump
    if(Input.GetKeyDown(KeyCode.Space) && isGrounded){
        theRB.AddForce(jump * jumpForce, ForceMode.Impulse);
        isGrounded = false;
      }
        animator.SetBool("onGround", isGrounded);
        animator.SetFloat("moveSpeed", moveDirection.magnitude);
        animator.SetBool("movingBackwards", movingBackwards);
        moveDirection.y = 0f;
        transform.position += moveDirection.normalized * moveSpeed * Time.deltaTime;
        if(moveDirection != Vector3.zero){
            transform.rotation = Quaternion.RotateTowards(transform.rotation, 
            Quaternion.LookRotation(moveDirection), rotationSpeed * Time.deltaTime);
        }

        
    
    }
    
    void CollisionCheck(){

        if(touchingChest){
            if(Input.GetKey(KeyCode.E)){
                //TODO CHEST ANIMATION
                Destroy(GameObject.FindWithTag("Chest"));
                Debug.Log("Interacting with chest");
                touchingChest = false;
                eKey.SetActive(false);
            }
        }
        else if(touchingDoor){
            if(Input.GetKey(KeyCode.E)){
                //TODO DOOR ANIMATION
                Destroy(GameObject.FindWithTag("Door"));
                Debug.Log("Interacting with door");
                touchingDoor = false;
                eKey.SetActive(false);
            }
        }  
    }

    void Update()
    {
        if(!playerDeath){
            Movement();
        }
        CollisionCheck();
        HealthCheck();
    //Interaction Handler
        if(Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(10);
        }
        

        
    }

    void HealthCheck(){
        if(currentHealth <= 0 && playerDeath == false){
            playerDeath = true;
            DeathScreen();
            Debug.Log("DEBUG: Death Screen reached");
        } else {
            //TODO: Get pressure plate win set up.
            //WinScreen();
        }
    }

    void DeathScreen(){
        lossScreenUI.SetActive(true);
        Time.timeScale = 0f;
    }

    /*
    void WinScreen()
    {
        winScreenUI.SetActive(true);
        Time.timeScale = 0f;
    }*/

    //Restart level and exit to main menu handler

    public void Restart()
    {
        SceneManager.LoadScene("Eric");
        Time.timeScale = 1f;
        Debug.Log("Loading new scene...");
    }

    /*
    public void ExitToMenu()
    {
        Debug.Log("Loading menu...");
        SceneManager.LoadScene("StartScene");
    }*/




        
        
    //Direction Handler
     void OnTriggerEnter(Collider other) {
            if (other.tag == "Chest") {
                touchingChest = true;
                Debug.Log("entering chest collider");
                eKey.SetActive(true);
            }
            else if (other.tag == "Door") {
                touchingDoor = true;
                Debug.Log("entering door collider");
                eKey.SetActive(true);
            }
            else if (other.tag == "MobProj") {
                TakeDamage(25);
                //Destroy(GameObject.FindGameObjectsWithTag("MobProj"));
                //TODO: Set mob projectiles with tag MobProj

            }
        }
        
    void OnTriggerExit(Collider other) {
        if (other.tag == "Chest") {
            touchingChest = false;
            Debug.Log("exiting door collider");
            eKey.SetActive(false);
        }
        else if (other.tag == "Door") {
            touchingDoor = false;
            Debug.Log("exiting door collider");
            eKey.SetActive(false);
        }
        
    }   
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
  
  void AddEctoplasm(int ectoCounter)
  {
    currentEctoplasm = ectoCounter;
    ectoplasmBar.SetEctoplasm(currentEctoplasm);
  }
 

        
    
}
    

