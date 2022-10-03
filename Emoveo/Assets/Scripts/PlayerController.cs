using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed;
    public float moveInput;

    public bool facingRight = true;
    
    public float jumpForce;
    public bool isGrounded = true;
    public Transform feetPosition;
    public float checkRadius;
    public LayerMask whatIsGrounded;

    private Rigidbody2D rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPosition.position, checkRadius, whatIsGrounded);

        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.velocity = Vector2.up * jumpForce;
        }
    }

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
        rigidbody.velocity = new Vector2(moveInput * playerSpeed, rigidbody.velocity.y);
        if (facingRight == false && moveInput > 0)
        {
            PlayerFlip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            PlayerFlip();
        }
    }
}