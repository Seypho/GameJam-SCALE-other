using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] AudioClip pickupSFX;
    [SerializeField] int scoreValue = 100;
    [SerializeField] int healthValue = 0;
    [SerializeField] float volume = 1f;
    bool wasCollected = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !wasCollected)
        {
            wasCollected = true;
            AudioSource.PlayClipAtPoint(pickupSFX, Camera.main.transform.position, volume);
            Destroy(gameObject);
            FindFirstObjectByType<GameSession>().ProcessScore(scoreValue);
            FindFirstObjectByType<GameSession>().AddLife(healthValue); ;
        }
    }
}
