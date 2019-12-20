using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Customized_YuYang : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        Hide();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{

        //    Show();
        //}
    }
    void Hide()
    {
        Time.timeScale = 1.0f;
        canvasGroup.alpha = 0f; //this makes everything transparent
        canvasGroup.blocksRaycasts = false; //this prevents the UI element to receive input events
        

    }

    void Show()
    {
        Time.timeScale = 0.0f;
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }

    public void SetButtonDown()
    {
        Show();
    }

    public void RedButtonDown()
    {
        rend.material.SetColor("_Color", Color.red);
        Hide();
    }
    public void BlueButtonDown()
    {
        rend.material.SetColor("_Color", Color.blue);
        Hide();


    }
    public void GreenButtonDown()
    {
        rend.material.SetColor("_Color", Color.green);
        Hide();


    }
}
