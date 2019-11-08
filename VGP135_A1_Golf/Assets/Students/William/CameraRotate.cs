using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public Ball ball;

    Vector3 originalPosition;
    Quaternion originalRotation;

    Vector3 changedPosition;
    Vector3 changedRotation;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;
        changedPosition = new Vector3(10f, 7f, 0f);
        changedRotation = new Vector3(20f, -90f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (ball.transform.position.z > 47.5f)
        {
            transform.localPosition = changedPosition;
            transform.localRotation = Quaternion.Euler(changedRotation);
        }
        else
        {
            transform.localPosition = originalPosition;
            transform.localRotation = originalRotation;
        }
    }
}
