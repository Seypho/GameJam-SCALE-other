using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float bulletSpeed = 5f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity = new Vector2(Mathf.Sign(transform.rotation.x) * bulletSpeed, 0f);
    }
}
