using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleBumper : MonoBehaviour
{
    Rigidbody rigidBody = null;
    public float forceApplied = 100.0f;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        if(!rigidBody)
        {
            Debug.LogError("Bumper must have a rigidbody!");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 direction = collision.transform.position - transform.position;
        direction.Normalize();
        direction.y = 0.0f;

        collision.rigidbody.AddForceAtPosition(direction * forceApplied, collision.GetContact(0).point);
    }
}