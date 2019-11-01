using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class GoalableObject : MonoBehaviour
{
    Rigidbody rb;

    public void Awake()
    {
        rb = GetComponent<Rigidbody>();
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
}
