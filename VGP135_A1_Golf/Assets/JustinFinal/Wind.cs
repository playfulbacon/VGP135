using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    public float force = 25.0f;

    public Vector3 direction;

    public GameObject particle;
    private void Start()
    {
        Vector3 norm =  Vector3.Normalize(direction);
        particle.transform.LookAt(new Vector3(norm.x,particle.transform.position.y, norm.z));
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            other.attachedRigidbody.AddForce(force * Vector3.Normalize(direction), ForceMode.Force);
        }
    }

}
