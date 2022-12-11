using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool abilityToMove;
    public bool abilityToSprint;
    public bool abilityToDash;

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
    private Animator animator;
    
    //healthbar
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    //get component Rigidbody when game started
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    //taking damage
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    //getting heal
    public void GetHeal(int heal)
    {
        currentHealth += heal;
        healthBar.SetHealth(currentHealth);
    }

    private void Sprint()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && moveInput != 0 && !isDashing && abilityToMove && abilityToSprint)
        {
            playerSpeed += sprintForce;
            isSprinting = true;
        }
        
        if (Input.GetKeyUp(KeyCode.LeftControl) && isSprinting && abilityToMove && abilityToSprint)
        {
            playerSpeed -= sprintForce;
            isSprinting = false;
        }
    }
    
    private void Dash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && moveInput != 0 && !isDashing && !isSprinting && abilityToMove && abilityToDash)
        {
            isDashing = true;
            currentDashTimer = startDashTimer;
            
            playerSpeed += dashForce;
        }
        
        if (isDashing && abilityToMove && abilityToDash)
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
    
        //jump
        if (isGrounded && Input.GetKeyDown(KeyCode.Space) && abilityToMove)
        {
            rigidbody.velocity = Vector2.up * jumpForce;
        }

        if (abilityToMove)
        {
            rigidbody.velocity = new Vector2(moveInput * playerSpeed, rigidbody.velocity.y);
            animator.SetBool("IsMoving", moveInput * playerSpeed != 0);
        }

        if (!abilityToMove && moveInput == 0)
        {
            animator.SetBool("IsMoving", false);
        }
        
        //damage
        if (Input.GetKeyDown(KeyCode.G))
        {
            TakeDamage(20);
        }
        
        //heal
        if (Input.GetKeyDown(KeyCode.H))
        {
            GetHeal(10);
        }

        Sprint();
        Dash();
    }

    //flipping player texture
    private void PlayerFlip()
    {
        if (abilityToMove)
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
       if (!facingRight && moveInput > 0 && abilityToMove)
        {
            PlayerFlip();
        }
        else if (facingRight && moveInput < 0 && abilityToMove)
        {
            PlayerFlip();
        }
    }
}
