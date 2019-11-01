using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeGoal : Goal
{
    public GameObject text;

    void Start()
    {
        text.gameObject.SetActive(false);   
    }

    public override void OnHit()
    {
        text.gameObject.SetActive(true);
    }

    public void SetTextInactive()
    {
        text.gameObject.SetActive(false);
    }
}
