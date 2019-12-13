using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundTimer : MonoBehaviour
{
    [SerializeField] float roundTimer = 5.0f;
    [SerializeField] Text timerText;
    [SerializeField] GameObject gameMenuCanvas;
    void Update()
    {
        roundTimer -= Time.deltaTime;
        if (roundTimer < 0.0f)
            roundTimer = 0.0f;
        timerText.text = roundTimer.ToString("F1");
        if (roundTimer <= 0.0f)
        {
            gameMenuCanvas.GetComponent<GoalMenu>().SetGoalMenu(true);
            Time.timeScale = 0;
        }
    }
}
