using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneInitializer : MonoBehaviour
{
    public GameObject scoretracker;
    // Start is called before the first frame update
    void Start()
    {
        if(GameObject.FindGameObjectWithTag("ScoreTracker") == null)
        {
            Instantiate(scoretracker);
            scoretracker.tag = "ScoreTracker";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
