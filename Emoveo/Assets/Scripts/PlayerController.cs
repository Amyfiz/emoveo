using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //variables for moving player left and right
    [SerializeField] private float currentSpeed;

    [SerializeField] private float playerSpeed;
    [SerializeField] private float playerSprintSpeed;
    [SerializeField] private float moveInput;

    //variable for flipping player texture
    [SerializeField] private bool facingRight = true;
    
    //variables for jump
    [SerializeField] private float jumpForce;
    [SerializeField] private bool isGrounded = true;
    [SerializeField] private Transform feetPosition;
    [SerializeField] private float checkRadius;
    [SerializeField] private LayerMask whatIsGrounded;

    private Rigidbody2D rigidbody;

    //get component Rigidbody when game started
    private void Awake() => rigidbody = GetComponent<Rigidbody2D>();
    
    private void Move()
    {
        if (isGrounded && moveInput != 0 && Input.GetKeyDown(KeyCode.LeftControl))
        {
            rigidbody.velocity = new Vector2(moveInput * playerSprintSpeed, rigidbody.velocity.y);
            currentSpeed = playerSprintSpeed;
            print("WIIIIIIIIIIIIIIIIIIIOOOOOOOOOOO");
        }
        else
        {
            rigidbody.velocity = new Vector2(moveInput * playerSpeed, rigidbody.velocity.y);
            currentSpeed = playerSpeed;
        }
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPosition.position, checkRadius, whatIsGrounded);

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.velocity = Vector2.up * jumpForce;
        }

        Move();
    }

    //flipping player texture
    private void PlayerFlip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    private void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        //test
        
        //Move();

        //flipping player according to side they're facing
       if (facingRight == false && moveInput > 0)
        {
            PlayerFlip();
        }
        else if (facingRight && moveInput < 0)
        {
            PlayerFlip();
        }
    }
}
