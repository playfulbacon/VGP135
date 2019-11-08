using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallKevinXu : MonoBehaviour
{
    Rigidbody rb;
    bool isPressed = false;
    bool isDragging = false;
    public Transform aimPrefab;
    Vector3 hitDirection;
    float hitForce = 100f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        aimPrefab = Instantiate(aimPrefab);
        aimPrefab.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
           hitForce = 100f;
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            hitForce = 300f;
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            hitForce = 600f;
        }


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
        fail failkey = other.attachedRigidbody?.GetComponent<fail>();

        if (goal)
        {
            goal.OnHit();
            rb.isKinematic = true;
        }

        if(failkey)
        {
            failkey.OnGround();
            rb.isKinematic = true;
        }
    }

   
}
