using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class LichengBall : MonoBehaviour
{
    Rigidbody rb;
    bool isPressed = false;
    bool isDragging = false;
    public Transform aimPrefab;
    Vector3 hitDirection;
    float hitForce = 1000f;

    // Licheng Zhou Edit --------------------------//|
    public bool IsGoalable = true;                 //|
    //---------------------------------------------//|

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        aimPrefab = Instantiate(aimPrefab);
        aimPrefab.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.isKinematic = true;
            isPressed = true;
        }

        if (isPressed)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(ray, out hit))
            {
                Vector3 groundHit = hit.point;
                groundHit.y = transform.position.y;

                if (Vector3.Distance(transform.position, groundHit) > 0.5f)
                {
                    isDragging = true;
                    aimPrefab.gameObject.SetActive(true);

                    hitDirection = -(groundHit - transform.position).normalized;
                    aimPrefab.transform.forward = hitDirection;
                    aimPrefab.position = transform.position + hitDirection * 1.25f;
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            rb.isKinematic = false;
            isPressed = false;
            aimPrefab.gameObject.SetActive(false);

            if (isDragging)
                rb.AddForce(hitDirection * hitForce);

            isDragging = false;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        Goal goal = other.attachedRigidbody?.GetComponent<Goal>();
        if (goal && IsGoalable)
        {
            goal.OnHit();
            rb.isKinematic = true;
        }
    }
}
