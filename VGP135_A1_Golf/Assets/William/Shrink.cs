using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrink : MonoBehaviour
{
    Vector3 originalSize;
    private void Start()
    {
        originalSize = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if((50.0f - transform.position.z) > 30)
        {
            transform.localScale = originalSize * (50.0f - transform.position.z) / 50.0f;
        }
    }
}
