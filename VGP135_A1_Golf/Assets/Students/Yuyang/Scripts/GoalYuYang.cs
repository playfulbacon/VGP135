using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalYuYang : MonoBehaviour
{
    void Start()
    {

 
    }

    public virtual void OnHit()
    {
        FindObjectOfType<GoalMenuYuYang>().SetGoalMenu(true);
    }

    public void NotHit()
    {
        FindObjectOfType<Level2GoalMenu>().SetGoalMenu2(true);
    }
}
