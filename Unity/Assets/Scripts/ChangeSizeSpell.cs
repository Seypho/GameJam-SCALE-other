using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSizeSpell : MonoBehaviour
{
    [SerializeField] float maxSize = 5f;
    [SerializeField] float minSize = .5f;
    [SerializeField] float sizeIncreaseAmount = 0.1f;
    [SerializeField] float sizeDecreaseAmount = -0.1f;
    Animator animator;
    PlayerMovement playerMovement;
    Rigidbody2D rb;

    private void Start()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            TargetObject(sizeIncreaseAmount * Time.deltaTime);
        }

        else if (Input.GetMouseButton(1))
        {
            TargetObject(sizeDecreaseAmount * Time.deltaTime);
        }
        else
        {
            animator.SetBool("isCasting", false);
            playerMovement.enabled = true;
        }
    }

    void TargetObject(float amount)
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        if (hit.collider != null && hit.collider.CompareTag("Object"))
        {
            Transform targetedObjectTransform = hit.collider.transform;
            Vector3 currentSize = targetedObjectTransform.localScale;
            // Increase the size of the targeted object
            Vector3 newSize = targetedObjectTransform.localScale + new Vector3(amount, amount, 0f);
            if (amount > 0 && currentSize.x >= maxSize || amount < 0 && currentSize.x <= minSize)
            {
                animator.SetBool("isCasting", false);
                playerMovement.enabled = true;
                return; 
            }
            animator.SetBool("isCasting", true);
            targetedObjectTransform.localScale = newSize;
            playerMovement.enabled = false;
            rb.velocity = new Vector2(0, rb.velocityY);
        }
    }

}
