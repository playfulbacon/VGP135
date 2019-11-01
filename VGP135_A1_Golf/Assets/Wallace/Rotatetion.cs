using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotatetion : MonoBehaviour
{
    public float rotationRate = 10.0f;

    void Update()
    {
        transform.Rotate(Vector3.down, rotationRate * Time.deltaTime);
    }
}
