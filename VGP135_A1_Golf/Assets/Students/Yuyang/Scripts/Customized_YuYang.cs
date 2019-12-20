using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Customized_YuYang : MonoBehaviour
{
    // Start is called before the first frame update
    public Shader reds;
    public Shader blues;
    public Shader greens;
    public Renderer rend;
    //public GameObject red;
    //public GameObject green;
    //public GameObject blue;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RedButtonDown()
    {
        Time.timeScale = 0;
        rend.material.color = Color.red;
    }
    public void BlueButtonDown()
    {
        Time.timeScale = 0;
        rend.material.shader = blues;
    }
    public void GreenButtonDown()
    {
        Time.timeScale = 0;
        rend.material.shader = greens;
    }
}
