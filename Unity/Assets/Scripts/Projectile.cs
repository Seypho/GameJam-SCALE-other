using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float bulletSpeed = 5f;
    Vector3 mousePosition;
    Vector2 shootDirection;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        shootDirection = (mousePosition - transform.position);
        Flip();
    }

    void Update()
    {
        rb.velocity = new Vector2 (shootDirection.x, shootDirection.y).normalized * bulletSpeed;
    }

    void Flip()
    {
        float angle = Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Object")
        {
            Destroy(gameObject);
        }
    }
}
