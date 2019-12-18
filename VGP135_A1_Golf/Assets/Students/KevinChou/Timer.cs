using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    Text mText;
    int h, m, s;
    float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        mText = GetComponent<Text>();
        s = 0;
        m = 0;
        h = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        s = (int)time;
        if (time > 60)
        {
            time = 0;
            m++;
        }
        if(m > 60)
        {
            m = 0;
            h++;
        }
        mText.text = "Session Playtime: " + h.ToString() + "h " + m.ToString() + "m " + s.ToString() + "s";
    }
}
