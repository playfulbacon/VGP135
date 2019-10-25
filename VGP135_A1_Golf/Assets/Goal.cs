using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
    public Text goalText;

    void Start()
    {
        goalText.gameObject.SetActive(false);    
    }

    public void OnGoal()
    {
        goalText.gameObject.SetActive(true);
    }
}
