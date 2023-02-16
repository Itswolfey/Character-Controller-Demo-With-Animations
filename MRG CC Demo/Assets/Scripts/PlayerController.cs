using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private bool canJump;
    [SerializeField] private bool moveLeft;
    [SerializeField] private bool moveRight;
    [SerializeField] private bool jumped;
    [SerializeField] private Transform playerVisual;
    [SerializeField] private float rayCastDis = 0.1f;
    

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        playerVisual = GameObject.Find("Player Visual").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        MovementRead();
    }
    void FixedUpdate()
    {
        MovementPerform();
    }

    void MovementRead()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, rayCastDis);

        if (hit)
        {
            canJump = true;
        }
        else
        {
            canJump = false;
        }



        if (Input.GetKeyDown(KeyCode.A))
        {
            moveLeft = true;
            animator.SetBool("Move", true);
        } 
        
        if (Input.GetKeyUp(KeyCode.A))
        {
            moveLeft = false;
            animator.SetBool("Move", false);
        }
        

        if (Input.GetKeyDown(KeyCode.D))
        {
            moveRight = true;
            animator.SetBool("Move", true);
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            moveRight = false;
            animator.SetBool("Move", false);
        }


        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            jumped = true;
            animator.SetTrigger("Jump");
           
        }

        

    }


    void MovementPerform()
    {
        if (moveLeft)
        {
            //rb.AddForce(-transform.right * walkSpeed);
            rb.velocity = new Vector2(-1, rb.velocity.y) * walkSpeed;

            playerVisual.transform.localScale = new Vector2(-1, 1);
        }

        if (moveRight)
        {
            //rb.AddForce(transform.right * walkSpeed);
            rb.velocity = new Vector2(1, rb.velocity.y) * walkSpeed;

            playerVisual.transform.localScale = new Vector2(1, 1);
        }

        if (jumped)
        {
            rb.AddForce(transform.up * jumpForce);
            jumped = false;
            
        }

        

    }

    
}
