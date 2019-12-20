using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GodModeManager : MonoBehaviour
{
    public GameObject button;
    private bool isActive;
    // Start is called before the first frame update
    void Start()
    {
        isActive = false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void GodModeActive()
    {
        isActive = !isActive;
        if (isActive)
        {
            button.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
            FindObjectOfType<PlayerMovement>().GodModeOn();
        }
        else
        {
            button.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            FindObjectOfType<PlayerMovement>().GodModeOff();


        }


    }
}
