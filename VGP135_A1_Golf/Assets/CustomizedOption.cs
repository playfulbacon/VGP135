using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizedOption : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    // Start is called before the first frame update
    void Start()
    {
        Hide();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            Show();
        }
    }
    void Hide()
    {

            canvasGroup.alpha = 0f; //this makes everything transparent
            canvasGroup.blocksRaycasts = false; //this prevents the UI element to receive input events

    }

    void Show()
    {
        Time.timeScale = 0.0f;
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }
}
