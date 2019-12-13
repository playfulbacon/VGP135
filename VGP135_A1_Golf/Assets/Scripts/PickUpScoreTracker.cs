using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScoreTracker : MonoBehaviour
{
    public int Score;
    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
