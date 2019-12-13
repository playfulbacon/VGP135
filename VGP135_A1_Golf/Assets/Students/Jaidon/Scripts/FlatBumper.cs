using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlatBumper : MonoBehaviour
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
        Vector3 direction = collision.GetContact(0).point - transform.position;

        direction.y = 0.0f;
        direction.Normalize();

        float reflect = Vector3.Dot(direction, Vector3.right);

        if(reflect < 0)
        {
            direction = Vector3.Reflect(direction, Vector3.right);
        }
        else
        {
            direction = Vector3.Reflect(direction, Vector3.left);
        }

        collision.rigidbody.AddForceAtPosition(direction * forceApplied, collision.GetContact(0).point);
    }
}