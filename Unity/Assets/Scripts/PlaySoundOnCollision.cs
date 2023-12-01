using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnCollision : MonoBehaviour
{
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GameObject.Find("SoundSource").GetComponent<AudioSource>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        BoxCollider2D boxCollider = collision.collider.GetComponent<BoxCollider2D>();

        if (collision.gameObject.tag == "Player" && boxCollider != null)
        {
            audioSource.Play();
        }
    }
}
