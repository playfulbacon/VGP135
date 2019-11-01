using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level2Goal : MonoBehaviour
{
    void Start()
    {


    }

    public virtual void OnHit()
    {
        FindObjectOfType<Level2GoalMenu>().SetGoalMenu(true);
    }

    public void NotHit()
    {
        FindObjectOfType<Level2GoalMenu>().SetGoalMenu2(true);
    }
}