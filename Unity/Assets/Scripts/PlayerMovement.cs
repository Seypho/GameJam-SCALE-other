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
    [SerializeField] LayerMask jumpableLayers;
    BoxCollider2D feetCollider;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        feetCollider = GetComponent<BoxCollider2D>();
    }


    void Update()
    {
        Move();
    }

    void Move()
    {
        float speed = rawInput.x * moveSpeed;
        rb.velocity = new Vector2(speed, rb.velocityY);
    }

    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        if (!isGrounded()) { return; }
        if(value.isPressed)
        {
            rb.velocity += new Vector2(0f, jumpStrength);
        }
    }

    bool isGrounded()
    {
        return feetCollider.IsTouchingLayers(jumpableLayers);
    }
}
