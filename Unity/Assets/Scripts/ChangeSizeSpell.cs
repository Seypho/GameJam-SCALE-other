using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSizeSpell : MonoBehaviour
{
    [SerializeField] float maxSize = 5f;
    [SerializeField] float minSize = .5f;
    [SerializeField] float sizeIncreaseAmount = 0.1f;
    [SerializeField] float sizeDecreaseAmount = -0.1f;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            TargetObject(sizeIncreaseAmount);
        }

        if (Input.GetMouseButton(1))
        {
            TargetObject(sizeDecreaseAmount);
        }
    }

    void TargetObject(float amount)
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
        Transform targetedObjectTransform = hit.collider.transform;
        Vector3 currentSize = targetedObjectTransform.localScale;



        if (hit.collider != null && hit.collider.CompareTag("Object"))
        {
            // Increase the size of the targeted object
            Vector3 newSize = targetedObjectTransform.localScale + new Vector3(amount, amount, 0f);
            targetedObjectTransform.localScale = newSize;
        }
    }
}
