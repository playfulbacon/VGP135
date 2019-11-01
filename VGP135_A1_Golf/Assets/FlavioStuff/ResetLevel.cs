using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetLevel : MonoBehaviour
{
    public Transform posToRestTo;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Ball>())
        {
            if (posToRestTo)
            {
                collision.gameObject.transform.position = posToRestTo.position;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
