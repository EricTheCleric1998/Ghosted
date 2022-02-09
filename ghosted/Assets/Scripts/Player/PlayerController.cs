using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //The player
    public Rigidbody theRB;
    public float moveSpeed, jumpForce;
    private Vector2 moveInput;

    public GameObject magicPrefab;
    public LayerMask whatIsGround;
    public Transform groundPoint;
    private bool isGrounded;

    //Reference to Animator
    public Animator animator;

    public SpriteRenderer theSR;

    private bool movingBackwards;

    public Animator flipAnim;

    //Detect if you are on the ground


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        moveInput.Normalize();

        theRB.velocity = new Vector3(moveInput.x * moveSpeed, theRB.velocity.y , moveInput.y * moveSpeed);

        animator.SetFloat("moveSpeed", theRB.velocity.magnitude);
        RaycastHit hit;

        if (Physics.Raycast(groundPoint.position, Vector3.down, out hit, .3f, whatIsGround))
        {

            isGrounded = true;
        }
        else {
            isGrounded = false;

        }

        if (Input.GetButtonDown("Jump") && isGrounded) {
            theRB.velocity += new Vector3(0f,jumpForce,0f);
        }

        animator.SetBool("onGround", isGrounded);
        
        // Changed all greater than signs to less than and vice versa. Change back if broken.
        // Changed signs of X axis after flipping the signs originally. It worked.

        if (!theSR.flipX && moveInput.x < 0) {
            theSR.flipX = true;
            flipAnim.SetTrigger("Flip");
        }
        else if (theSR.flipX && moveInput.x > 0)
        {
            theSR.flipX = false;
            flipAnim.SetTrigger("Flip");

        }
        if (!movingBackwards && moveInput.y < 0) {
            movingBackwards = true;
            flipAnim.SetTrigger("Flip");

        }
        else if (movingBackwards && moveInput.y > 0) {
            movingBackwards = false;
            flipAnim.SetTrigger("Flip");

        }
        animator.SetBool("movingBackwards", movingBackwards);

        if(Input.GetMouseButtonDown(0)){

        }
    }
}

