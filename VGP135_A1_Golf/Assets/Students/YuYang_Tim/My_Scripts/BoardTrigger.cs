using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Board;
    
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
       
        Board.transform.Rotate(-20.0f, 0.0f, 0.0f);
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    Board.transform.Rotate(45.0f, 0.0f, 0.0f);
    //}
}
