using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePad : MonoBehaviour
{
    public float bounceStrength = 20.0f;
    public void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y + bounceStrength, rb.velocity.z);
    }
}
