using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCoin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if(other.CompareTag("Ball"))
        {
            if(GameObject.FindGameObjectWithTag("ScoreTracker") != null)
            {
                //Debug.Log("I am supposed to work");
                GameObject.FindGameObjectWithTag("ScoreTracker").GetComponent<PickUpScoreTracker>().Score++;
                //Destroy(this);
                Destroy(gameObject);

            }
        }
    }
}
