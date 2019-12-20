using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Customized_YuYang : MonoBehaviour
{
    // Start is called before the first frame update
    public Renderer rend;
    //public GameObject red;
    //public GameObject green;
    //public GameObject blue;
    

    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        /// Debug Purposes
    }


    public void RedButtonDown()
    {
        rend.material.SetColor("_Color", Color.red);
    }
    public void BlueButtonDown()
    {
        rend.material.SetColor("_Color", Color.blue);

    }
    public void GreenButtonDown()
    {
        rend.material.SetColor("_Color", Color.green);

    }
}
