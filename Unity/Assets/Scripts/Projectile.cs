using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float bulletSpeed = 5f;
    PlayerMovement player;
    float xSpeed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindFirstObjectByType<PlayerMovement>();
        xSpeed = player.transform.localScale.x * bulletSpeed;
        Flip();
    }

    void Update()
    {
        rb.velocity = new Vector2 (xSpeed, 0);
    }

    void Flip()
    {
        if(player.transform.localScale.x < 0)
        {
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
