using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool abilityToWalk = true;
    public DialogueManager dialogueManager;
    
    //variables for moving player left and right
    [SerializeField] private float playerSpeed;
    [SerializeField] private float sprintForce;
    [SerializeField] private float dashForce;

    public float startDashTimer;
    public float currentDashTimer;
    
    [SerializeField] private float moveInput;

    [SerializeField] private bool isSprinting;
    [SerializeField] private bool isDashing;

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

    private void Sprint()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && moveInput != 0 && !isDashing && abilityToWalk)
        {
            playerSpeed += sprintForce;
            isSprinting = true;
        }
        
        if (Input.GetKeyUp(KeyCode.LeftControl) && isSprinting && abilityToWalk)
        {
            playerSpeed -= sprintForce;
            isSprinting = false;
        }
    }
    
    private void Dash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && moveInput != 0 && !isDashing && !isSprinting && abilityToWalk)
        {
            isDashing = true;
            currentDashTimer = startDashTimer;
            
            playerSpeed += dashForce;
        }
        
        if (isDashing && abilityToWalk)
        {
            currentDashTimer -= Time.deltaTime;

            if (currentDashTimer <= 0)
            {
                isDashing = false;
                playerSpeed -= dashForce;
            }
        }
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPosition.position, checkRadius, whatIsGrounded);

        if (isGrounded && Input.GetKeyDown(KeyCode.Space) && abilityToWalk)
        {
            rigidbody.velocity = Vector2.up * jumpForce;
        }
        
        if (dialogueManager.isDialogueOpen == true)
        {
            abilityToWalk = false;
        }
        else
        {
            abilityToWalk = true;
        }

        if (abilityToWalk)
        {
            rigidbody.velocity = new Vector2(moveInput * playerSpeed, rigidbody.velocity.y);
        }

        Sprint();
        Dash();
    }

    //flipping player texture
    private void PlayerFlip()
    {
        if (abilityToWalk)
        {
            facingRight = !facingRight;
            Vector3 scaler = transform.localScale;
            scaler.x *= -1;
            transform.localScale = scaler;
        }
    }

    private void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");

        //keeping player on the same Y while dashing
        if (isDashing)
        {
            rigidbody.velocity = new Vector2(moveInput * playerSpeed, 0);
        }

        

        //flipping player according to side they're facing
       if (!facingRight && moveInput > 0)
        {
            PlayerFlip();
        }
        else if (facingRight && moveInput < 0)
        {
            PlayerFlip();
        }
    }
}
