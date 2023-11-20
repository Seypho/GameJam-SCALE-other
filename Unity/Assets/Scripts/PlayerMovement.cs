using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 rawInput;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpStrength = 5f;
    [SerializeField] float jumpPressedRememberTime = 0.2f;
    [SerializeField] float isGroundedRememberTime = 0.2f;
    [SerializeField] LayerMask jumpableLayers;
    float isGroundedRemember = 0f;
    float jumpPressedRemember = 0f;
    BoxCollider2D feetCollider;
    bool facingRight = true;
    Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        feetCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        Timers();
        Move();
        Jump();
        isGrounded();
        updateAnimationState();
    }

    void Move()
    {
        float speed = rawInput.x * moveSpeed;
        rb.velocity = new Vector2(speed, rb.velocityY);
        Flip();
    }


    void Flip()
    {

        if (rawInput.x < 0 && facingRight)
        {
            facingRight = false;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
        else if (rawInput.x > 0 && !facingRight)
        {
            facingRight = true;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }
    void Timers()
    {
        jumpPressedRemember -= Time.deltaTime;
        isGroundedRemember -= Time.deltaTime;
    }
    void Jump()
    {
        if ((jumpPressedRemember > 0) && (isGroundedRemember > 0))
        {
            jumpPressedRemember = 0;
            isGroundedRemember = 0;
            rb.velocity = new Vector2(rb.velocityX, jumpStrength);
        }
    }
    void isGrounded()
    {
        if (feetCollider.IsTouchingLayers(jumpableLayers))
        {
            isGroundedRemember = isGroundedRememberTime;
        }
    }

    void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            jumpPressedRemember = jumpPressedRememberTime;
        }
    }

    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
    }
    void updateAnimationState()
    {
        if (Mathf.Abs(rb.velocityX) > 0)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }
}


































