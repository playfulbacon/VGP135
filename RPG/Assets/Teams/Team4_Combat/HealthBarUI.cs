using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    Slider slider;
    Stats stats;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        stats = FindObjectOfType<Player>().GetComponent<Stats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (stats)
            slider.value = (1 - stats.GetHealthPercentage());
        else
            slider.value = 0f;
    }
}
