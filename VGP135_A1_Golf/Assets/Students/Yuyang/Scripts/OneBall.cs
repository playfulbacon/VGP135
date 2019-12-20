using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class OneBall : MonoBehaviour
{
    Rigidbody rb;
    bool isPressed = false;
    bool isDragging = false;
    bool isWon = false;
    float moveCount = 0;
    public Transform aimPrefab;
    Vector3 hitDirection;
    float hitForce = 1000f;
    public GoalYuYang goal2;
    float timeCount = 0;
    //public CustomizedOption cp;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        aimPrefab = Instantiate(aimPrefab);
        aimPrefab.gameObject.SetActive(false);
        timeCount = 0;
        
    }

    void Update()
    {
        Failure();
        Debug.Log(timeCount);
        timeCount += Time.fixedDeltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            rb.isKinematic = true;
            isPressed = true;
        }

        if (isPressed && (moveCount<1))
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
            moveCount++;
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
        if (goal)
        {
            goal.OnHit();
            rb.isKinematic = true;
            isWon = true;
            moveCount = 0;
            timeCount = 0;
        }
    }

    public void Failure()
    {       
        if (moveCount == 1 && (isWon == false) && ((timeCount>25)))
        {
            goal2.NotHit();
            rb.isKinematic = true;
            moveCount = 0;
            //timeCount = 0;
        }
        
    }


}
