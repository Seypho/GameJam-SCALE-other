using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerState : MonoBehaviour
{
    PlayerInput myPlayerInput;
    Animator myAnimator;
    Rigidbody2D myRigidbody;
    CapsuleCollider2D myBodyCollider;
    [SerializeField] float tookDamageTime = 2f;
    [SerializeField] float tookDamage = 0f;
    bool isAlive = true;
    GameSession gameSession;
    [SerializeField] AudioClip deathSFX;
    [SerializeField] Vector2 deathKick = new Vector2(100f, 100f);

    void Awake()
    {
        myAnimator = GetComponent<Animator>();
        myPlayerInput = GetComponent<PlayerInput>();
        myRigidbody = GetComponent<Rigidbody2D>();
        myBodyCollider = GetComponent<CapsuleCollider2D>();
        gameSession = GetComponent<GameSession>();
        tookDamage = 0f;
    }

    private void Update()
    {
        if (!isAlive) { return; }
        Timers();
        TakeDamage();
    }
    void Timers()
    {
        tookDamage -= Time.deltaTime;
    }

    void TakeDamage()
    {
        if (myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemy", "Hazard")) && tookDamage <= 0)
        {
            myAnimator.SetTrigger("Damage");
            myRigidbody.velocity = deathKick;
            AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position);
            tookDamage = tookDamageTime;
        }
        if (FindFirstObjectByType<GameSession>().playerLives <= 0 && isAlive)
        {
            isAlive = false;
            myPlayerInput.enabled = false;
            myAnimator.SetTrigger("Dying");
            myRigidbody.velocity = deathKick;
            AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position);
        }
    }

    void ReloadOnDeath()
    {
        FindFirstObjectByType<GameSession>().ProcessPlayerDeath();
    }
}
