using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class SergioPlayerController : MonoBehaviour
{
    //The player
    public Rigidbody theRB;
    public float moveSpeed, jumpForce, gravity;
    private Vector2 moveInput;
    public Vector3 jump, gg;
    Vector3 moveDirection;
    public LayerMask whatIsGround;
    public Transform groundPoint;
    private bool isGrounded;
    public Animator animator;
    public SpriteRenderer theSR;
    private bool movingBackwards;
    public Animator flipAnim;
    public float rotationSpeed;
    public Transform FPSCam;
    public Transform TPSCam;
    public Inventory inventory;
    public Transform respawn,r1, r2, r3;
    public int maxHealth = 50;
    public int currentHealth;
   
   
    public HealthBarScript healthBar;
    public EctoplasmBarScript ectoplasmBar;
    public int startEctoplasm= 0;
    public int currentEctoplasm;

   
    private bool touchingDoor;
    public GameObject xKey;
    public bool touchingChest;
    public GameObject chestGet;
    public Key getKey;
    
  

    public int playerHealth;
    public bool playerDeath;
    
    


    //Jump set
    void Start()
    {

        respawn = r1;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        currentEctoplasm = startEctoplasm;
        theRB = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, jumpForce, 0.0f);
        gg = new Vector3(0.0f, gravity, 0.0f);
        theRB.AddForce(jump * jumpForce, ForceMode.Impulse);
        ectoplasmBar.SetEctoplasm(startEctoplasm);

    }

    //Jump Collision Start
    void OnCollisionStay()
    {
        isGrounded = true;

    }
    //Jump Collision Exit
    void OnCollisionExit()
    {
        isGrounded = false;
        //Debug.Log("Norp");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Trig1")
        {
            respawn = r2;

        }
        if (other.gameObject.tag == "Trig2")
        {
            respawn = r3;

        }


         if (other.tag == "Chest") {
                touchingChest = true;
                Debug.Log("entering chest collider");
                xKey.SetActive(true);
            }
            else if (other.tag == "Door") {
                touchingDoor = true;
                Debug.Log("entering door collider");
                xKey.SetActive(true);
            }
      

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Fire")
        {
            Debug.Log("YOU DIED");
            theRB.transform.position = respawn.transform.position;
            
        }
        if (collision.gameObject.tag == "Wall")
        {
            Debug.Log("Hit the walls");
            theRB.velocity = Vector3.zero;
        }
        if (collision.gameObject.tag == "Object")
        {
            Debug.Log("Object");
            IInventoryItem item = collision.collider.GetComponent<IInventoryItem>();
            if (item != null)
            {
                Debug.Log("ITEM HIT");
                inventory.AddItem(item);
            }
            Destroy(collision.gameObject);
        }
       
        if (collision.gameObject.tag == "Attack")
        {
            Debug.Log("AVADAKADAVRA");
            currentHealth -= 2;
            healthBar.SetHealth(currentHealth);
            Destroy(collision.gameObject);
        }


    }


        // Update is called once per frame
    void Update()
    {
        Transform relativeTransform;

        theRB.AddForce(gg, ForceMode.Impulse);
        Vector3 moveDirection = Vector3.zero;
        Cursor.visible = true;
        theRB.AddForce(jump * jumpForce, ForceMode.Force);

        if (TPSCam.gameObject.activeInHierarchy) {
            //Debug.Log("NOT FPS");
            theSR.GetComponent<SpriteRenderer>().enabled = true;
            relativeTransform = TPSCam;        
        }else{
            //Debug.Log("FPS");
            theSR.GetComponent<SpriteRenderer>().enabled = false;
            relativeTransform = FPSCam;
        }
        


        //Direction Handler
        if (Input.GetKey(KeyCode.W))
        {
            moveDirection += relativeTransform.forward; 
        }
        else if (Input.GetKey(KeyCode.S))
        {
            moveDirection += -relativeTransform.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveDirection += -relativeTransform.right;

        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveDirection += relativeTransform.right;
        }
        //Animation Handler
        if (!movingBackwards && Input.GetKeyDown(KeyCode.W))
        {
            movingBackwards = true;
            flipAnim.SetTrigger("Flip");
        }
        else if (movingBackwards && Input.GetKeyDown(KeyCode.S))
        {
            movingBackwards = false;
            flipAnim.SetTrigger("Flip");
        }
        if (!theSR.flipX && Input.GetKeyDown(KeyCode.A))
        {
            theSR.flipX = true;
            flipAnim.SetTrigger("Flip");
        }
        else if (theSR.flipX && Input.GetKeyDown(KeyCode.D))
        {
            theSR.flipX = false;
            flipAnim.SetTrigger("Flip");
        }

        RaycastHit hit;

        if (Physics.Raycast(groundPoint.position, Vector3.down, out hit, .3f, whatIsGround))
        {
            isGrounded = true;

        }
        else
        {
            isGrounded = false;

        }

        //Adding force to the rigid body to jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            theRB.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
        animator.SetBool("onGround", isGrounded);
        animator.SetFloat("moveSpeed", moveDirection.magnitude);
        animator.SetBool("movingBackwards", movingBackwards);
        moveDirection.y = 0f;
        transform.position += moveDirection.normalized * moveSpeed * Time.deltaTime;
        if (moveDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation,
            Quaternion.LookRotation(moveDirection), rotationSpeed * Time.deltaTime);
        }

        EctoplasmBar();

    }

    void EctoplasmBar()
    {
        if(currentEctoplasm <= 1000)
        {
            int runningTotal = startEctoplasm + EctoplasmAddSystem.theNumber;
            AddEctoplasm(runningTotal);
          
        }else{
            
            Debug.Log("Cannot collect anymore ectoplasm!");
        }
    }

    void AddEctoplasm(int ectoCounter)
    { 
        currentEctoplasm = ectoCounter;
        ectoplasmBar.SetEctoplasm(currentEctoplasm);
    }

    void CollisionCheck(Key key, Image image)
    {

        if(touchingChest){
            if(Input.GetKey(KeyCode.X)){
                //TODO CHEST ANIMATION
              
                //Destroy(GameObject.FindWithTag("Chest"));
                if(GameObject.FindWithTag("Chest") != null)
                {
                    chestGet.GetComponent<Animator>().SetBool("open",touchingChest);
                    Debug.Log("Interacting with chest");
                    touchingChest = false;
                    xKey.SetActive(false);
                    if(inventory!=null)
                    {
                        Destroy(key.GetComponent<Image>());
                    }
                
                
                }
               
               
            }
        }
        else if(touchingDoor){
            if(Input.GetKey(KeyCode.X)){
                //TODO DOOR ANIMATION
                Destroy(GameObject.FindWithTag("Door"));
                Debug.Log("Interacting with door");
                touchingDoor = false;
                xKey.SetActive(false);
            }
        }  
    }

    void OnTriggerExit(Collider other) {
        if (other.tag == "Chest") {
            touchingChest = false;
            Debug.Log("exiting door collider");
            xKey.SetActive(false);
        }
        else if (other.tag == "Door") {
            touchingDoor = false;
            Debug.Log("exiting door collider");
            xKey.SetActive(false);
        }
        
    }  

   

   
}
