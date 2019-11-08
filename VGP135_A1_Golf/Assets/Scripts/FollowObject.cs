using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    GameObject objectToFollow;
    public float followSpeed = 5f;

    void Start()
    {
        objectToFollow = FindObjectOfType<Ball>().gameObject;
    }

    void Update()
    {
        Vector3 targetPosition = objectToFollow.transform.position;
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * followSpeed);
    }
}
