using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    public bool addf = false;
    public float mForce = 100.0f;
    public Collider o;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (addf == true)
        {
            o.transform.parent.GetComponent<Rigidbody>().AddForce(transform.right * mForce);
            //o.GetComponent<Rigidbody>().AddForce(transform.right * mForce);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered");
        if(other.CompareTag("Player"))
        {
            o = other;
            addf = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exited");
        if(other.CompareTag("Player"))
        {
            o = null;
            addf = false;
        }
    }
}
