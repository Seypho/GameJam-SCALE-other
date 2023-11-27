using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FireSpell : MonoBehaviour
{
    Animator animator;
    [SerializeField] GameObject spellPrefab;
    [SerializeField] Transform spellOrigin;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnFire(InputValue value)
    {
        if (value.isPressed)
        {
            Instantiate(spellPrefab, spellOrigin.position, spellOrigin.rotation);
        }
    }
}
