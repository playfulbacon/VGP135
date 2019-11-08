using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanRotation : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale > 0.0)
            gameObject.transform.Rotate(0.0f, 0.0f, speed * Time.unscaledDeltaTime);
    }
}
