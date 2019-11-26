﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// Required Function from other team
// [Character Status] GetMovementSpeed()

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 5.0f;
    [SerializeField]
    private float rotationSpeed = 5.0f;
    private NavMeshAgent agent;
    private bool isMoving;

    // - Getter & Setter -----------------------------------------------------------------------
    public bool IsMoving        { get { return isMoving; }}
    public NavMeshAgent Agent   { get { return agent;    }}

    // - MonoBehavior functions ----------------------------------------------------------------
    void Awake()
    {
        // speed = GetComponent<CharacterStatus>().GetMovementSpeed();
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(ray, out hit))
            {
                Vector3 groundHit = hit.point;
                agent.destination = groundHit;
            }
        }

        isMoving = Vector3.SqrMagnitude(agent.velocity) > 1.0f;

        //Enemy currentTarget = AttackManager.GetCurrentTarget();           //|
        //if (currentTarget)                                                //|--- TODO:: Ask team 4 to provid this function
            //RotateTowards(currentTarget.transform);                       //|
    }

    private void RotateTowards(Transform target)
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }
}
