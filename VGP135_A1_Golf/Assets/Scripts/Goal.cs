using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
    public Text Timer;

    void Start()
    {
 
    }

    public virtual void OnHit()
    {
        Timer.text = FindObjectOfType<TimeCount>().GetTimeCount();
        FindObjectOfType<TimeCount>().gameObject.SetActive(false);
        FindObjectOfType<GoalMenu>().SetGoalMenu(true);
    }
}
