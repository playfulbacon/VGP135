using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneInitializer : MonoBehaviour
{
    public GameObject sessionTimer;



    // Start is called before the first frame update
    void Start()
    {
        if(GameObject.FindGameObjectWithTag("SessionTimer") == null)
        {
            Instantiate(sessionTimer);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
