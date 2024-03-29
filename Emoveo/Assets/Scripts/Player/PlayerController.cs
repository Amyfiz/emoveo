using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Player player;
    private Rigidbody2D rigidbody;
    private Animator animator;

    //get component Rigidbody when game started
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    public void Sprint()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && player.moveInput != 0 && !player.isDashing && player.abilityToMove && player.abilityToSprint)
        {
            player.playerSpeed += player.sprintForce;
            player.isSprinting = true;
        }
        
        if (Input.GetKeyUp(KeyCode.LeftControl) && player.isSprinting && player.abilityToMove && player.abilityToSprint)
        {
            player.playerSpeed -= player.sprintForce;
            player.isSprinting = false;
        }
    }
    
    public void Dash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && player.moveInput != 0 && !player.isDashing && !player.isSprinting && player.abilityToMove && player.abilityToDash)
        {
            player.isDashing = true;
            player.currentDashTimer = player.startDashTimer;
            
            player.playerSpeed += player.dashForce;
        }
        if (player.isDashing && player.abilityToMove && player.abilityToDash)
        {
            player.currentDashTimer -= Time.deltaTime;

            if (player.currentDashTimer <= 0)
            {
                player.isDashing = false;
                player.playerSpeed -= player.dashForce;
            }
        }
    }

    public void Jump()
    {
        //jump
        if ((player.isGrounded || player.isSticked) && player.abilityToMove)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                player.isJumping = true;
                player.jumpTimeCounter = player.jumpTime;
                rigidbody.velocity = Vector2.up * player.jumpForce;
            }
        }

        if (Input.GetKey(KeyCode.Space) && player.isJumping)
        {
            if (player.jumpTimeCounter > 0)
            {
                rigidbody.velocity = new Vector2(player.moveInput * player.playerSpeed,player.jumpForce);
                player.jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                player.isJumping = false;
            }
        }

        if(Input.GetKeyUp(KeyCode.Space) && player.abilityToMove)
        {
            player.isJumping = false;
        }
    }

    private void Update()
    {
        player.isGrounded = Physics2D.OverlapCircle(player.feetPosition.position, player.checkRadius, player.whatIsGrounded);
        player.isSticked = Physics2D.OverlapCircle(player.feetPosition.position, player.checkRadius, player.whatIsSticky);

        if (player.abilityToMove)
        {
            rigidbody.velocity = new Vector2(player.moveInput * player.playerSpeed, rigidbody.velocity.y);
            
            if (player.isDashing)
            {
                animator.SetBool("IsDashing", true);
            }
            else
            {
                animator.SetBool("IsDashing", false);
            }
            
            if (player.isSprinting)
            {
                animator.SetBool("IsSprinting", true);
            }
            else
            {
                animator.SetBool("IsSprinting", false);
            }
            
            animator.SetBool("IsMoving", player.moveInput * player.playerSpeed != 0);
        }

        if (!player.abilityToMove && player.moveInput == 0)
        {
            animator.SetBool("IsMoving", false);
        }

        if (player.isDashing)
        {
            animator.SetBool("IsDashing", true);
        }
        else
        {
            animator.SetBool("IsDashing", false);
        }

        Jump();
        Sprint();
        Dash();
    }

    //flipping player texture
    private void PlayerFlip()
    {
        if (player.abilityToMove)
        {
            player.facingRight = !player.facingRight;
            Vector3 scaler = transform.localScale;
            scaler.x *= -1;
            transform.localScale = scaler;
        }
    }

    private void FixedUpdate()
    {
        player.moveInput = Input.GetAxis("Horizontal");

        //keeping player on the same Y while dashing
        if (player.isDashing)
        {
            rigidbody.velocity = new Vector2(player.moveInput * player.playerSpeed, 0);
        }

        

        //flipping player according to side they're facing
       if (!player.facingRight && player.moveInput > 0 && player.abilityToMove)
        {
            PlayerFlip();
        }
        else if (player.facingRight && player.moveInput < 0 && player.abilityToMove)
        {
            PlayerFlip();
        }
    }
}
