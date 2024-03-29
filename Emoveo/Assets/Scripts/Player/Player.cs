using UnityEngine;

public class Player : MonoBehaviour
{
    public bool abilityToMove;
    public bool abilityToSprint;
    public bool abilityToDash;
    

    //variables for moving player left and right
    [SerializeField] public float playerSpeed;
    [SerializeField] public float sprintForce;
    [SerializeField] public float dashForce;

    public float startDashTimer;
    public float currentDashTimer;
    
    [SerializeField] public float moveInput;

    [SerializeField] public bool isSprinting;
    [SerializeField] public bool isDashing;
    [SerializeField] public bool isJumping;

    //variable for flipping player texture
    [SerializeField] public bool facingRight = true;
    
    //variables for jump
    [SerializeField] public float jumpForce;
    [SerializeField] public bool isGrounded = true;
    [SerializeField] public bool isSticked = false;
    [SerializeField] public Transform feetPosition;
    [SerializeField] public float checkRadius;
    [SerializeField] public LayerMask whatIsGrounded;
    [SerializeField] public LayerMask whatIsSticky;
    [SerializeField] public Transform headPosition;

    [SerializeField] public float jumpTimeCounter;
    [SerializeField] public float jumpTime;
    
    protected internal bool abilityToBreakWalls;
    
    //
    [SerializeField] public float normalGravity;
    [SerializeField] public float stickyGravity;

}
