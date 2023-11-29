using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FireSpell : MonoBehaviour
{
    Animator animator;
    [SerializeField] GameObject spellPrefab;
    [SerializeField] Transform spellOrigin;
    SpellSelector spellSelector;
    void Start()
    {
        animator = GetComponent<Animator>();
        spellSelector = GetComponent<SpellSelector>();
    }

    void OnFire(InputValue value)
    {
        if (value.isPressed && spellSelector.currentSpellIndex == 0)
        {
            Instantiate(spellPrefab, spellOrigin.position, spellOrigin.rotation);
        }
    }
}
