using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attach : MonoBehaviour
{
    public GameObject Ball;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == Ball)
        {
            Ball.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Ball)
        {
            Ball.transform.parent = null;
        }
    }

}
