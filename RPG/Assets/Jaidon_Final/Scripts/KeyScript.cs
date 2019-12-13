using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    public int keyValue = -1;
    public bool isUnique = false;       // If it is unique, a regular door will not consume the key

    public float height = 1.0f;  // Bigger number will vary the float more
    public float minimum = 0.5f;  // Bigger number will vary the float more

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x,  (Mathf.Sin(Time.time) * height) + minimum, transform.position.z);
    }
}