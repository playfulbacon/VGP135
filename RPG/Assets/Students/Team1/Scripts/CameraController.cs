using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject objectToFollow;
    public float followSpeed = 5f;

    void Start()
    {
        if (objectToFollow == null)
            objectToFollow = FindObjectOfType<PlayerMovement>().gameObject;
    }

    void Update()
    {
        Vector3 targetPosition = objectToFollow.transform.position;
        Vector3 newPosition = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * followSpeed);
        transform.position = new Vector3(newPosition.x, transform.position.y, newPosition.z);
    }
}
