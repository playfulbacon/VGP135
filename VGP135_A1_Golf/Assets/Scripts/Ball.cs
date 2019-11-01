using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.IO;

[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{
    Rigidbody rb;
    bool isPressed = false;
    [SerializeField]
    bool isDragging = false;
    public Transform aimPrefab;
    Vector3 hitDirection;
    float hitMaxForce = 1000f;

    [SerializeField]
    float currentForce = 0f;

    [SerializeField]
    Vector3 mouseStartPosition;
    [SerializeField]
    Vector3 mouseFinalPosition;

    float forcePercentage = 0.0f;

    public float maxForceDistance = 300.0f;

    float slowPercentage = 0.5f;

    bool isClicked = false;

    [SerializeField]
    float currentForceDistance;

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
                    if (!isClicked)
                    {
                        mouseStartPosition = Input.mousePosition;
                        isClicked = true;
                    }
                    aimPrefab.gameObject.SetActive(true);

                    hitDirection = -(groundHit - transform.position).normalized;
                    aimPrefab.transform.forward = hitDirection;
                    aimPrefab.position = transform.position + hitDirection * 1.25f;
                }
            }
        }

        if (isDragging)
        {
            mouseFinalPosition = Input.mousePosition;
            if (currentForceDistance < maxForceDistance)
                currentForceDistance = (mouseFinalPosition - mouseStartPosition).magnitude;
            else
                currentForceDistance = maxForceDistance - 0.1f;
            forcePercentage = currentForceDistance / maxForceDistance;

            //aimPrefab.localScale += new Vector3(aimPrefab.localScale.x, aimPrefab.localScale.y, aimPrefab.localScale.z * forcePercentage);
        }

        if (Input.GetMouseButtonUp(0))
        {
            currentForce = hitMaxForce * forcePercentage;

            rb.isKinematic = false;
            isPressed = false;
            aimPrefab.gameObject.SetActive(false);

            if (isDragging)
                rb.AddForce(hitDirection * currentForce);

            isDragging = false;
            currentForce = 0.0f;

            isClicked = false;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        Goal goal = other.attachedRigidbody?.GetComponent<Goal>();
        if (goal)
        {
            goal.OnHit();
            rb.isKinematic = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        FakeGoal fakegoal = other.attachedRigidbody?.GetComponent<FakeGoal>();
        if(fakegoal)
        {
            fakegoal.SetTextInactive();
        }
    }
}
