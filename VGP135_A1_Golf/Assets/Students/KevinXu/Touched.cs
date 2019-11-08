using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touched : MonoBehaviour
{
    public GameObject Ball;

    // Start is called before the first frame update
    void Start()
    {

        
    }

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
